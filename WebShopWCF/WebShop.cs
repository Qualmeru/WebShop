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
        public void Register(Person person)
        {
        //   Model.PersonDTO newPerson =new Model.PersonDTO(person);
          Person personp = new Person(person);
          db.Persons.Add(personp);
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
            var finduser = (from u in db.Persons
                            where u.UserName == userName
                            select new Model.PersonDTO(u)
                           ).FirstOrDefault();
            return finduser;
        }

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
                Model.GenreDTO newGenre = new Model.GenreDTO();
                newGenre.Products = genre.Products.Select(f => new Model.ProductDTO(f)).ToList();
                genres.Add(newGenre);
            }
            return genres;
        }

        public Order GetOrder()
        {
            //TODO get Order
            return new Order();
        }

        public List<Model.ProductDTO> GetallProduct()
        {
            //TODO get Products
            return new List<Model.ProductDTO>();
        }

        public Product Product()
        {
            //TODO get product
           return new Product();
        }
    }
}
