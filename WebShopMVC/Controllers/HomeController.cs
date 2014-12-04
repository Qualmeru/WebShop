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
            viewmodeluser.Products = proxy.GetallProduct().ToList();
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
        public PartialViewResult Products(int genreid, int consoleid)
        {
            var httpCookie = Response.Cookies["Product"].Value;
            var games = (from g in proxy.GetallProduct()
                         from ge in g.Genres
                         from c in g.Konsols
                         where ge.Id == genreid && c.Id == consoleid
                         select g).ToList();


            return PartialView(games);
        }

        public ActionResult BuyProduct(int productid, int st, int genreid, int consoleid)
        {
            var username = User.Identity.Name;
            var getuser = proxy.FindUser(username);


            ModelCartDTO newcart = new ModelCartDTO
            {
                Antal = st,
                ProductId = productid,
                GenreId = genreid,
                KonsoleId = consoleid,

                KeyToken = DateTime.UtcNow.Ticks.ToString()
            };
            if (!string.IsNullOrWhiteSpace(username))
            {
                newcart.UserId = getuser.Id;
            }

            int id = proxy.AddCart(newcart);
            HttpCookie newCookie = new HttpCookie("Product", id.ToString());
            newCookie.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Add(newCookie);

            var httpCookie = Response.Cookies["Product"].Value;

            return RedirectToAction("Products", new { genreid, consoleid });
        }
        public ActionResult Admin()
        {
            viewmodeluser viewmodeluser = new viewmodeluser();

            var username = User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
            {
                var user = proxy.FindUser(username);
                viewmodeluser.Person = user;
                viewmodeluser.Genres = proxy.GetAllGenres();
                viewmodeluser.Consoles = proxy.GetAllConsoles();
           
            if (user.Admins == ModelPersonDTO.Admin.AdminMember)
            {
                return View(viewmodeluser);
            }
            
            }
            return RedirectToAction("index");
        }
        public ActionResult AddProduct(string productname, int price, int yearofrelease, string Pic_loc, int konsole, int Genre)
        {
            ModelProductDTO newp = new ModelProductDTO { ProductName = productname, Price = price,PicLocation = Pic_loc, YearOfRelease = yearofrelease };

            newp.Genres = new ModelGenreDTO[1];
            newp.Genres[0] = new ModelGenreDTO { Id = Genre };

            newp.Konsols = new ModelKonsolDTO[1];
			 newp.Konsols[0] = new ModelKonsolDTO { Id = konsole };

            proxy.AddProduct(newp);
        
			
            return RedirectToAction("Admin");
        }
        public ActionResult Search()
        {

            return View();
        }
    }
}
