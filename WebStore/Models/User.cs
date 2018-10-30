using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class User
    {
        public User ( string userName, string password, bool isAdmin)
        {
            this.UserName = userName;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.IsDeleted = false;
        }

        public User()
        {

        }

        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}