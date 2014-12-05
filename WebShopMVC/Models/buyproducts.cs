using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShopMVC.Models
{
    public class buyproducts
    {
        public int Id { get; set; }
        public string KeyToken { get; set; }
        public int ProductId { get; set; }
        public int KonsoleId { get; set; }
        public int GenreId { get; set; }
        public int Antal { get; set; }
        
        public int? UserId { get; set; }
    }
}