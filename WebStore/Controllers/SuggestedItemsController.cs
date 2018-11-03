using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using Newtonsoft.Json;
using Accord.Statistics.Filters;
using System.Data;
using Accord.MachineLearning;
using Accord.Math;

namespace WebStore.Controllers
{
    public class SuggestedItemsController : Controller
    {
        private WebStoreContext db = new WebStoreContext();

        // GET: SuggestedItems
        public ActionResult Index()
        {
            return View("SuggestedItems");
        }
        public ActionResult SuggestedItems()
        {
            var userId = HttpContext.Session["UserID"];
           

            if (userId != null)
            {
                int id = (int)userId;
                var orders = db.Orders.Where(x => x.UserID == id).Select(x => x.ID).ToList();

                if(orders.Count !=0 )
                {
                    var trainData = db.Orders.Join(db.Items,
                                o => o.ItemID,
                                i => i.ItemID,
                                (o, i) => new
                                {
                                    UserID = o.UserID,
                                    Gender = i.Gender,
                                    Brand = i.Brand,
                                    ItemTypeId = i.ItemTypeId
                                }).OrderBy(x => x.UserID).ToList();


                    DataTable table = new DataTable("");
                    table.Columns.Add("ItemTypeId", typeof(int));
                    table.Columns.Add("Brand", typeof(string));
                    table.Columns.Add("Gender", typeof(string));
                    foreach (var row in trainData)
                    {
                        table.Rows.Add(row.ItemTypeId, row.Brand, row.Gender);
                    }

                    var codebook = new Codification(table);

                    DataTable result = codebook.Apply(table);

                    // The resulting table can be transformed to jagged array:
                    double[][] matrix = Matrix.ToJagged(result);

                    KMedoids kmeans = new KMedoids(k: 2)
                    {

                    };


                    var clusters = kmeans.Learn(matrix);
                    int[] labels = clusters.Decide(matrix);

                    var purchasesById = db.Orders.Join(db.Items,
                    o => o.ItemID,
                    i => i.ItemID,
                    (o, i) => new
                    {
                        UserID = o.UserID,
                        Gender = i.Gender,
                        Brand = i.Brand,
                        ItemTypeId = i.ItemTypeId
                    }).GroupBy(x => x.UserID).ToList();

                    IList<Tuple<int, int[]>> labelsForUsers = new List<Tuple<int, int[]>>();

                    // מתאים כל רכישה למבנה למידה
                    for (int i = 0; i < purchasesById.Count; i++)
                    {
                        table.Clear();

                        foreach (var row in purchasesById[i])
                        {
                            table.Rows.Add(row.ItemTypeId, row.Brand, row.Gender);
                        }

                        codebook = new Codification(table);

                        result = codebook.Apply(table);

                        // The resulting table can be transformed to jagged array:
                        double[][] newUserInputs = Matrix.ToJagged(result);
                        //var Currentlusters = kmeans.Learn(newUserInputs);
                        int[] currentLabels = clusters.Decide(newUserInputs).Distinct();

                        // יקח את כל הרכישות של יוזר שנמצאות בלאסטר 
                        labelsForUsers.Add(new Tuple<int, int[]>(purchasesById[i].Key, currentLabels));

                    }
                    var itemIdsUserBought = db.Orders
                        .Where(x => x.UserID == id)
                        .Select(x => x.ItemID)
                        .Distinct()
                        .ToList();

                    var productsToPredict = db.Items
                        .Where(x => !itemIdsUserBought.Contains(x.ItemID))
                        .Select(x => new
                        {
                            id = x.ItemID,
                            Brand = x.Brand,
                            Gender = x.Gender,
                            ItemTypeId = x.ItemTypeId
                        }).ToList();


                    table.Clear();

                    foreach (var row in productsToPredict)
                    {
                        table.Rows.Add(row.ItemTypeId, row.Brand, row.Gender);
                    }

                    codebook = new Codification(table);

                    DataTable ItemInputs = codebook.Apply(table);

                    // The resulting table can be transformed to jagged array:
                    double[][] NewItemInputs = Matrix.ToJagged(ItemInputs);


                    int[] lol = clusters.Decide(NewItemInputs);

                    IList<int> productIdsPrediction = new List<int>();
                    var userLabels = labelsForUsers.Where(x => x.Item1 == id).FirstOrDefault().Item2;
                    for (int i = 0; i < lol.Length; i++)
                    {
                        if (userLabels.Contains(lol[i]))
                        {
                            productIdsPrediction.Add(productsToPredict[i].id);
                        }
                    }

                    var predictedProduct = db.Items
                        .Where(x => productIdsPrediction.Contains(x.ItemID))
                        .ToList();

                    return View("SuggestedItems", predictedProduct);
                }

            }
            return View("SuggestedItems", new List<Item>());
        }
    }
}