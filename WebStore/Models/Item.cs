using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebStore.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public int ItemTypeId { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string ImgPath { get; set; }
        public bool IsDeleted { get; set; }
    }
}


