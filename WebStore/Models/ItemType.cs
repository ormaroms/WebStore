using System;
using System.ComponentModel.DataAnnotations;


namespace WebStore.Models
{
    public class ItemType
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string name { get; set; }
    }
}