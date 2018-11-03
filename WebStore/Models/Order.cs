using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Linq.Mapping;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Odbc;
using System.Drawing.Imaging;

namespace WebStore.Models
{
    public class Order
    {

		[Key, System.ComponentModel.DataAnnotations.Schema.Column(Order = 0)]
		[System.Data.Linq.Mapping.Column(Storage = "OrderID", AutoSync = AutoSync.OnInsert,
		IsPrimaryKey = true, IsDbGenerated = true)]
		public int OrderID { get; set; }
        public int UserID { get; set; }
        [Key, System.ComponentModel.DataAnnotations.Schema.Column(Order = 1)]
        public int ItemID { get; set; }
        public int PickUpPointID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
		public int Quantity { get; set; }
    }
}  
 
 
 
