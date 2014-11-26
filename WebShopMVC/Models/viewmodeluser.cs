using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopMVC.WebShopWCF;

namespace WebShopMVC.Models
{
    public class viewmodeluser
    {
        public ModelKonsolDTO[] Consoles { get; set; }
        public ModelGenreDTO[] Genres { get; set; }
        public ModelPersonDTO Person { get; set; }
    }
}