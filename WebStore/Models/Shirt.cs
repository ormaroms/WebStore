using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    public class Shirt
    {
		[Key]
		public int ItemID { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string ImgPath { get; set; }
    }
}