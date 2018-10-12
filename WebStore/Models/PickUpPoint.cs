using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
    public class PickUpPoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float LocationLongitude { get; set; }
        public float LocationLatitude { get; set; }
    }
}