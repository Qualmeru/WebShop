﻿using System;
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
        public List<ModelOrderDTO> Order { get; set; }
        public ModelPersonDTO Person { get; set; }
        public List<ModelCartDTO> Carts { get; set; }
        public List<ModelProductDTO> Products { get; set; }
        public List<buyproducts> Buyproducts { get; set; } 
    }
}