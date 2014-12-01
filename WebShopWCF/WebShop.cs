using System;
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
            var orders = (from e in db.Orders
                          select new Model.OrderDTO(e)
                          {
                              OrderProduct = e.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList(),
                              Person = new Model.PersonDTO(e.Person)
                          }
                          ).ToList();

            return orders;
        }

        public Model.PersonDTO FindUser(string userName)
        {
            var finduser = new Model.PersonDTO();
            try
            {
                finduser = (from u in db.Persons
                            where u.UserName == userName
                            select new Model.PersonDTO(u)
                                           ).FirstOrDefault();
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
                Model.KonsolDTO newKonsol = new Model.KonsolDTO(konsol);
                newKonsol.Products = konsol.Products.Select(f => new Model.ProductDTO(f)).ToList();
                newKonsol.OrderProduct = konsol.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList();

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
                Model.GenreDTO newGenre = new Model.GenreDTO(genre);
                newGenre.Products = genre.Products.Select(f => new Model.ProductDTO(f)).ToList();
                genres.Add(newGenre);
            }
            return genres;
        }

        public Order GetOrder(int id)
        {
            var findorder = (from o in db.Orders
                             where o.Id == id
                             select o).SingleOrDefault();
            return findorder;

        }



        public List<Model.ProductDTO> GetallProduct()
        {
            //TODO get Products
            var prod = (from p in db.Products
                        select new Model.ProductDTO(p)
                        {
                            OrderProduct = p.OrderProduct.Select(f => new Model.OrderProductDTO(f)).ToList(),
                            Genres = p.Genres.Select(f => new Model.GenreDTO(f)).ToList(),
                            Konsols = p.Konsols.Select(f => new Model.KonsolDTO(f)).ToList()

                        }).ToList();
            return prod;
        }

        public Product Product(int id)
        {
            var findproduct = (from o in db.Products
                               where o.Id == id
                               select o).SingleOrDefault();
            return findproduct;
        }

        public void AddOrder(Model.OrderDTO order)
        {
            db.Orders.Add(order.GetDatabaseOrder());
            db.SaveChanges();
            db.Dispose();
        }

        public void AddOrderProduct(Model.OrderProductDTO orderProduct)
        {
            db.OrderProducts.Add(orderProduct.GetDataBaseOrderProduct());
            db.SaveChanges();
            db.Dispose();
        }

        public void AddCart(Model.CartDTO stock)
        {
            db.Carts.Add(stock.GetCartFromdb());
            db.SaveChanges();
            db.Dispose();
        }

        public List<Model.CartDTO> GetCartsByuserId(int userid)
        {
            var cart = (from c in db.Carts where c.UserId == userid select new Model.CartDTO(c)).ToList();
            return cart;
        }
    }
}
