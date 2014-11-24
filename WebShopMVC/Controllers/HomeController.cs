using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMVC.WebShopWCF;

namespace WebShopMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            WebShopClient proxy = new WebShopClient();
            var modelKonsolDtos = proxy.GetAllConsoles();
            ViewBag.modelKonsolDtos = modelKonsolDtos;
         
            return View();
        }

    }
}
