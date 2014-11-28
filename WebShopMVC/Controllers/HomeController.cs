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

            if (username != null && username != "")
            {
                viewmodeluser.Person = proxy.FindUser(username);

                viewmodeluser.Order = (from e in proxy.GetOrderList()
                                       where e.PersonId == viewmodeluser.Person.Id
                                       select e).ToList();
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
        public ActionResult BuyProduct(int id, int st, int genreid, int consoleid)
        {
            HttpCookie cookie = new HttpCookie(User.Identity.Name,
                string.Format("{0};{1};{2};{3}", id, st, genreid, consoleid));
            cookie.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Products", new { genreid, consoleid });
        }


    }
}
