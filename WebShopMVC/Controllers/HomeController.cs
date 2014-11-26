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

       
            ModelKonsolDTO[] modelKonsolDtos = proxy.GetAllConsoles();
            viewmodeluser ConsoleGenre = new viewmodeluser();


            var username =  User.Identity.Name;
            ConsoleGenre.Consoles = proxy.GetAllConsoles();
            ConsoleGenre.Genres = proxy.GetAllGenres();
            //ConsoleGenre.Person = proxy.FindUser(username);

            return View(ConsoleGenre);
        }
        public ActionResult genre(int id)
        {
            //var game = from g in proxy
            //           where 
            return View();
        }

    }
}
