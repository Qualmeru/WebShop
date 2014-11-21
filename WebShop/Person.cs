using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Person
    {

       
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email {get; set;}
        public enum Admin
        {
            User = 1,
            Admin = 2
        }
        public Admin Admins { get; set; }
        public virtual ICollection<Order> Order {get; set;}

    }
}
