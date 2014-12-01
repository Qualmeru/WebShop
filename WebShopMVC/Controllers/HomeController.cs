using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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

            if (!string.IsNullOrEmpty(username))
            {
                var user = proxy.FindUser(username);
                viewmodeluser.Person = user ;

                //viewmodeluser.Order = (from e in proxy.GetOrderList()
                //                       where e.PersonId == user.Id
                //                       select e).ToList();
                //viewmodeluser.Carts = proxy.GetCartsByuserId(user.Id).ToList();

            }


            return View(viewmodeluser);
        }
        public ActionResult Products(int genreid, int consoleid)
        {
            var games = (from g in proxy.GetallProduct()
                         from ge in g.Genres
                         from c in g.Konsols
                         where ge.Id == genreid && c.Id == consoleid
                         select g).ToList();


            return View(games);
        }
        [Authorize]
        public ActionResult BuyProduct(int productid, int st, int genreid, int consoleid)
        {
            var getuser = proxy.FindUser(User.Identity.Name);
            ModelCartDTO newcart = new ModelCartDTO
            {
                Antal = st,
                ProductId = productid,
                GenreId = genreid,
                KonsoleId = consoleid,
                UserId = getuser.Id,
                KeyToken = DateTime.UtcNow.Ticks.ToString()
            };
            proxy.AddCart(newcart);
            
            return RedirectToAction("Products", new { genreid, consoleid });
        }


    }
}
