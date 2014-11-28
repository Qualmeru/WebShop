using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopMVC.WebShopWCF;
using WebShopMVC.Models;

namespace WebShopMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/  

        WebShopClient proxy = new WebShopClient();

        public ActionResult Index()
        {



            viewmodeluser viewmodeluser = new viewmodeluser();


            var username = User.Identity.Name;

            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Genres = proxy.GetAllGenres();
            if (username != null)
                viewmodeluser.Person = proxy.FindUser(username);

            return View(viewmodeluser);
        }
        public ActionResult genre(int id)
        {
            //var game = from g in proxy
            //           where 
            return View();
        }

    }
}
