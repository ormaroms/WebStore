using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class PickUpPoint
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public bool IsDeleted { get; set; }

        public PickUpPoint(string name, double locationLongitude, double locationLatitude)
        {
            Name = name;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
        }

        public PickUpPoint()
        {
        }
    }
}