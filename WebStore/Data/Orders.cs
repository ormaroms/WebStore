//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int ItemID { get; set; }
        public int PickUpPointID { get; set; }
        public bool isDeleted { get; set; }
    
        public virtual PickUpPoints PickUpPoints { get; set; }
        public virtual Users Users { get; set; }
        public virtual Items Items { get; set; }
    }
}
