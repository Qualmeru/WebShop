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
            Person newPerson = new Person();
            person.FirstName = person.FirstName;
            newPerson.Admins = (Person.Admin)person.Admins;
            newPerson.Adress = person.Adress;
            newPerson.Email = person.Email;
            newPerson.UserName = person.UserName;
            newPerson.Order = (ICollection<Order>)person.Order;
            newPerson.PassWord = sha256(person.PassWord);
            db.Persons.Add(newPerson);
            db.SaveChanges();

        }

        public List<Model.OrderDTO> GetOrderList()
        {
            var orders = (from e in db.Orders
                select new Model.OrderDTO()
                {
                    Id = e.Id,
                    OrderProduct = (ICollection<Model.OrderProductDTO>) e.OrderProduct,
                    PersonId =  e.Person.Id

                }).ToList();

            return orders;
        }

        private string sha256(string password)
        {
            var crypto = SHA256.Create();
            string hash = string.Empty;
            byte[] hashbyte = crypto.ComputeHash(
                Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
            foreach (byte bit in hashbyte)
            {
                hash += bit.ToString("x2");

            }
            return hash;

        }
    }
}
