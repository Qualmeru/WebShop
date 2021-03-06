﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
        List<buyproducts> Buyproducts = new List<buyproducts>();


        public ActionResult Index()
        {


            viewmodeluser viewmodeluser = new viewmodeluser();


            var username = User.Identity.Name;

            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Genres = proxy.GetAllGenres();
            viewmodeluser.Products = proxy.GetallProduct().ToList();
            List<buyproducts> buyproducts = Session["Buyproducts"] as List<buyproducts>;

            if (buyproducts != null)
            {

                viewmodeluser.Buyproducts = buyproducts;
            }

            if (!string.IsNullOrEmpty(username))
            {
                var user = proxy.FindUser(username);
                viewmodeluser.Person = user;



            }


            return View(viewmodeluser);
        }
        public ActionResult _Products(int genreid, int consoleid)
        {



            var games = (from g in proxy.GetallProduct()
                         from ge in g.Genres
                         from c in g.Konsols
                         where ge.Id == genreid && c.Id == consoleid
                         select g).ToList();

            viewmodeluser viewmodeluser = new viewmodeluser();
            viewmodeluser.Products = games;
            viewmodeluser.Genres = proxy.GetAllGenres();
            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Buyproducts = Session["Buyproducts"] as List<buyproducts>;
            viewmodeluser.Person = proxy.FindUser(User.Identity.Name);
            return View("Index", viewmodeluser);
        }

        public ActionResult ShoppingCart()
        {
            viewmodeluser viewmodeluser = new viewmodeluser();
            var username = User.Identity.Name;
            if ( !string.IsNullOrWhiteSpace(username))
            viewmodeluser.Person = proxy.FindUser(username);
            viewmodeluser.Buyproducts = Session["Buyproducts"] as List<buyproducts>;
            viewmodeluser.Products = proxy.GetallProduct().ToList();
            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Genres = proxy.GetAllGenres();
            return View(viewmodeluser);
        }
        [HttpPost]
        public ActionResult BuyProduct(int productid, int st, int genreid, int consoleid)
        {

            var username = User.Identity.Name;
            var getuser = proxy.FindUser(username);

            viewmodeluser viewmodeluser = new viewmodeluser();
            viewmodeluser.Person = getuser;
            viewmodeluser.Genres = proxy.GetAllGenres();
            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Products = proxy.GetallProduct().ToList();
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

            string keyToken = proxy.AddCart(newcart);
            var key = Session["Key"];
            List<buyproducts> buyproducts = Session["Buyproducts"] as List<buyproducts>;
            if (buyproducts != null)
                buyproducts.Add(new buyproducts() { Antal = newcart.Antal, GenreId = newcart.GenreId, KeyToken = keyToken, KonsoleId = newcart.KonsoleId, ProductId = newcart.ProductId });
            else
            {
                Session["Buyproducts"] = Buyproducts;
                List<buyproducts> buyproducts2 = Session["Buyproducts"] as List<buyproducts>;
                if (buyproducts2 != null)
                    buyproducts2.Add(new buyproducts() { Antal = newcart.Antal, GenreId = newcart.GenreId, KeyToken = keyToken, KonsoleId = newcart.KonsoleId, ProductId = newcart.ProductId });
            }
            if (key == null)
            {

                Session["Key"] = keyToken;
            }





            return RedirectToAction("Index");
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
                viewmodeluser.Products = proxy.GetallProduct().ToList();

                if (user.Admins == ModelPersonDTO.Admin.AdminMember)
                {
                    return View(viewmodeluser);
                }

            }
            return RedirectToAction("index");
        }

        public ActionResult DeleteItemFromCart(string key)
        {
            viewmodeluser viewmodeluser = new viewmodeluser();

            var username = User.Identity.Name;
            if (!string.IsNullOrEmpty(username))
            {
                var user = proxy.FindUser(username);
                viewmodeluser.Person = user;
                viewmodeluser.Genres = proxy.GetAllGenres();
                viewmodeluser.Consoles = proxy.GetAllConsoles();
                viewmodeluser.Products = proxy.GetallProduct().ToList();

            }
            List<buyproducts> buyproducts = Session["Buyproducts"] as List<buyproducts>;
            if (buyproducts != null)
            {
                var product = (from e in buyproducts
                               where e.KeyToken == key
                               select e).Single();

                buyproducts.Remove(product);
            }

            return RedirectToAction("ShoppingCart");
        }

        public ActionResult DeleteProduct(int id)
        {
            var username = User.Identity.Name;
            var user = proxy.FindUser(username);
            if (user.Admins == ModelPersonDTO.Admin.AdminMember)
            {
                proxy.DeleteProduct(id);
            }
            return RedirectToAction("Admin");
        }
        public ActionResult AddProduct(string productname, int price, int yearofrelease, string Pic_loc, int konsole, int Genre)
        {
            ModelProductDTO newp = new ModelProductDTO { ProductName = productname, Price = price, PicLocation = Pic_loc, YearOfRelease = yearofrelease };

            newp.Genres = new ModelGenreDTO[1];
            newp.Genres[0] = new ModelGenreDTO { Id = Genre };

            newp.Konsols = new ModelKonsolDTO[1];
            newp.Konsols[0] = new ModelKonsolDTO { Id = konsole };

            proxy.AddProduct(newp);


            return RedirectToAction("Admin");
        }
        [HttpGet]
        public ActionResult Search(string search, string gengre)
        {


            if (string.IsNullOrEmpty(search))
            {
                return View("Index");
            }
            viewmodeluser viewmodeluser = new viewmodeluser();
            var searchtolower = search.ToLower();
            if (!gengre.Contains("alla") && gengre != null)
            {
                viewmodeluser.Products = (
                                          from p in proxy.GetallProduct()
                                          from a in p.Genres

                                          where p.ProductName.ToLower().Contains(searchtolower) &&
                                         a.Id == int.Parse(gengre) 
                                          select p).ToList();
            }
            else
            {
                viewmodeluser.Products = (from p in proxy.GetallProduct()
                    where p.ProductName.ToLower().Contains(searchtolower)
                    select p).ToList();
            }


            viewmodeluser.Person = proxy.FindUser(User.Identity.Name);
            viewmodeluser.Buyproducts = Session["BuyProducts"] as List<buyproducts>;
            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Genres = proxy.GetAllGenres();


            return View("Index", viewmodeluser);
        }
        public ActionResult GetConsole(int id)
        {
            viewmodeluser viewmodeluser = new viewmodeluser();
            viewmodeluser.Person = proxy.FindUser(User.Identity.Name);
            viewmodeluser.Buyproducts = Session["BuyProducts"] as List<buyproducts>;
            viewmodeluser.Consoles = proxy.GetAllConsoles();
            viewmodeluser.Genres = proxy.GetAllGenres();
            var products = (from p in proxy.GetallProduct()
                            from c in p.Konsols
                            where c.Id == id
                          select p).ToList();
           
            viewmodeluser.Products = products;
            return View("Index", viewmodeluser);
        }
        [Authorize]
        public ActionResult BuyProducts()
        {
            List<buyproducts> buyproducts = Session["Buyproducts"] as List<buyproducts>;
            var username = User.Identity.Name;
            var person = proxy.FindUser(username);
            if (buyproducts != null)
            {
                var order = new ModelOrderDTO() { PersonId = person.Id, KeyToken = DateTime.UtcNow.Ticks.ToString() };
                proxy.AddOrder(order);
                var orderlist = proxy.GetOrderList();
                var orders = (from o in proxy.GetOrderList()
                    where o.KeyToken == order.KeyToken
                    select o);
                foreach (var buyproduct in buyproducts)
                {
                    if (orders != null)
                    {
                        foreach (var orde in orders)
                        {
                            proxy.AddOrderProduct(new ModelOrderProductDTO() { KonsolId = buyproduct.KonsoleId, OrderId = orde.Id, ProductId = buyproduct.ProductId, Antal = buyproduct.Antal });
                        }
                       
                    }
                       
                }
                
                Session["Buyproducts"] = Buyproducts;
            }
            return RedirectToAction("Index");
        }
    }
}
