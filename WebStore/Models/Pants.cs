using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class Pants
    {
        public int ItemID { get; set; }
        public float Price { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string ImgPath { get; set; }
    }
}