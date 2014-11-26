using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Person
    {
        public Person()
        {
            Order = new HashSet<Order>();
        }

        public Person(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            Adress = person.Adress;
            LastName = person.LastName;
            UserName = person.UserName;
            PassWord = sha256(person.PassWord);
            Email = person.Email;
            Admins = person.Admins;

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

      

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public enum Admin
        {
            User = 1,
            Admin = 2
        }
        public Admin Admins { get; set; }
        public virtual ICollection<Order> Order { get; set; }

    }
}
