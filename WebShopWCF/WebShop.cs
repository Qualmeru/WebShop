﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShop;


namespace WebShopWCF
{
    class WebShop : IWebShop
    {
        MainDB db = new MainDB();
        public void Register(Model.PersonDTO person)
        {

            db.Persons.Add(person.getdatabaseperson());
            db.SaveChanges();

        }

        public List<Model.OrderDTO> GetOrderList()
        {
            db = new MainDB();
            var orderlist = db.Orders.ToList();
            List<Model.OrderDTO> orders = new List<Model.OrderDTO>();
            foreach (var order in orderlist)
            {
                var neworder = new Model.OrderDTO(order)
                  {
                      OrderProduct = order.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList(),
                      Person = new Model.PersonDTO(order.Person)
                  };
                orders.Add(neworder);
            }

            return orders;
        }

        public Model.PersonDTO FindUser(string userName)
        {
            var finduser = new Model.PersonDTO();
            try
            {
                var user = db.Persons.FirstOrDefault(f => f.UserName == userName);
                finduser = new Model.PersonDTO(user);
            }
            catch (Exception e)
            {
                error = e.Message;

            }

            return finduser;
        }

        public string error { get; set; }

        public List<Model.KonsolDTO> GetAllConsoles()
        {
            List<Konsol> kList = db.Konsols.ToList();

            List<Model.KonsolDTO> modelkonsol = new List<Model.KonsolDTO>();
            foreach (Konsol konsol in kList)
            {
                Model.KonsolDTO newKonsol = new Model.KonsolDTO(konsol)
                {
                    Products = konsol.Products.Select(f => new Model.ProductDTO(f)).ToList(),
                    OrderProduct = konsol.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList()
                };

                modelkonsol.Add(newKonsol);
            }

            return modelkonsol;
        }

        public List<Model.GenreDTO> GetAllGenres()
        {
            List<Genre> glist = db.Genres.ToList();
            List<Model.GenreDTO> genres = new List<Model.GenreDTO>();
            foreach (var genre in glist)
            {
                Model.GenreDTO newGenre = new Model.GenreDTO(genre)
                {
                    Products = genre.Products.Select(f => new Model.ProductDTO(f)).ToList()
                };
                genres.Add(newGenre);
            }
            return genres;
        }

        public Model.OrderDTO GetOrder(int id)
        {
           Order order =  db.GetOrderbyId(id);
         
            
            var findorder = new Model.OrderDTO(order);

            return findorder;

        }



        public List<Model.ProductDTO> GetallProduct()
        {
            //TODO get Products
            var prodlist = db.Products.ToList();
            List<Model.ProductDTO> products = new List<Model.ProductDTO>();
            foreach (var product in prodlist)
            {
                Model.ProductDTO newprod = new Model.ProductDTO(product)
                {
                    OrderProduct = product.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList(),
                    Genres = product.Genres.Select(f => new Model.GenreDTO(f)).ToList(),
                    Konsols = product.Konsols.Select(f => new Model.KonsolDTO(f)).ToList()
                };
                products.Add(newprod);
            }


            return products;
        }

        public Model.ProductDTO Product(int id)
        {
            var findprod = db.Products.SingleOrDefault(m => m.Id == id);

            var findproduct = new Model.ProductDTO(findprod);
            return findproduct;
        }
        public void AddProduct(Model.ProductDTO product)
        {

            Product newp = new Product();
            newp = product.GetDataBaseProduct();
            db.Products.Add(product.GetDataBaseProduct());
            foreach (var item in product.Genres)
            {
                newp.Genres.Add(db.Genres.First(f => f.Id == item.Id));
            }
            foreach (var item in product.Konsols)
            {
                newp.Konsols.Add(db.Konsols.First(f => f.Id == item.Id));
            }
            db.SaveChanges();
            db.Dispose();
        }

        public void AddOrder(Model.OrderDTO order)
        {
            db = new MainDB();
            db.Orders.Add(order.GetDatabaseOrder());
            db.SaveChanges();
          
        }

        public void AddOrderProduct(Model.OrderProductDTO orderProduct)
        {
           db = new MainDB();
            db.OrderProducts.Add(orderProduct.GetDataBaseOrderProduct());
            db.SaveChanges();
            db.Dispose();
        }

        public string AddCart(Model.CartDTO stock)
        {
            db = new MainDB();
            db.Carts.Add(stock.GetCartFromdb());

            db.SaveChanges();
            return stock.GetCartFromdb().KeyToken;
            db.Dispose();

        }

        public List<Model.CartDTO> GetCartsByuserId(int userid)
        {
            var cart = (from c in db.Carts where c.UserId == userid select c).ToList();
            List<Model.CartDTO> carts = new List<Model.CartDTO>();
            foreach (var item in cart)
            {
                var newcart = new Model.CartDTO(item);

                carts.Add(newcart);
            }

            return carts;
        }


        public void AddGenre(Model.GenreDTO genre)
        {
            db.Genres.Add(genre.ToDb());
            db.SaveChanges();
            db.Dispose();
        }

        public void AddConsole(Model.KonsolDTO konsol)
        {
            db.Konsols.Add(konsol.ToDB());
            db.SaveChanges();
            db.Dispose();
        }

        public void DeleteProduct(int id)
        {
            var prod = db.Products.SingleOrDefault(m => m.Id == id);
            db.Products.Remove(prod);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
