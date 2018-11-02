using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class Order
    {
        [Key, Column(Order = 0)]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int OrderID { get; set; }
        public int UserID { get; set; }
        [Key, Column(Order = 1)]
        public int ItemID { get; set; }
        public int PickUpPointID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }
		public int Quantity { get; set; }
    }
} 
 
 
 
