﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebStoreDBEntities : DbContext
    {
        public WebStoreDBEntities()
            : base("name=WebStoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pant> Pants { get; set; }
        public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }
        public virtual DbSet<Shirt> Shirts { get; set; }
        public virtual DbSet<Sho> Shoes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
