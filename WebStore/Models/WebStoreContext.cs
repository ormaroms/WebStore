using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebStore.Models
{
    public class WebStoreContext : DbContext
    {
        public DbSet<PickUpPoint> PickUpPoints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Pants> Pants { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemType> ItemType { get; set; }

        public WebStoreContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<WebStoreContext>(null);
        }
    }
}