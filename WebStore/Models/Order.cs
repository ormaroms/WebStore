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
		[Key]
		public int ID { get; set; }
		public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public int PickUpPointID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
		public int Quantity { get; set; }
    }
}  
 
 
 
