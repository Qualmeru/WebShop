using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebShop;

namespace WebShopWCF
{
    public class Model
    {
        [DataContract]
        public class PersonDTO
        {
            public PersonDTO()
            {
                Order = new HashSet<OrderDTO>();
            }

            public PersonDTO(Person u)
            {
                Id = u.Id;
                Admins = (Admin) u.Admins;
                Adress = u.Adress;
                Email = u.Email;
                FirstName = u.FirstName;
                LastName = u.LastName;
                Order = new HashSet<OrderDTO>();
                PassWord = u.PassWord;
                UserName = u.UserName;

            }

            public Person getdatabaseperson()
            {
               return new Person()
                {
                    FirstName = this.FirstName,
                    Admins = (Person.Admin)Admins,
                    Id = this.Id,
                    Adress = this.Adress,
                    Email = this.Email,
                    LastName =  this.LastName,
                    PassWord = sha256(this.PassWord),
                    UserName = this.UserName
                    
                };
                
            }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string Adress { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public string UserName { get; set; }
            [DataMember]
            public string PassWord { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataContract]
            [Flags]
            public enum Admin
            {
                [EnumMember]
                User = 1,
                [EnumMember]
                Admin = 2
            }
            [DataMember]
            public Admin Admins { get; set; }
            [DataMember]
            public virtual ICollection<OrderDTO> Order { get; set; }
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
       
        [DataContract]
        public class OrderDTO
        {
            public OrderDTO()
            {
                OrderProduct = new HashSet<OrderProductDTO>();
            }

            public OrderDTO( Order order)
            {
                Id = order.Id;
                PersonId = order.PersonId;
                Person = new PersonDTO();
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int PersonId { get; set; }

            [DataMember]
            public virtual PersonDTO Person { get; set; }
            [DataMember]
            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }
        }
        [DataContract]
        public class OrderProductDTO
        {
            public OrderProductDTO(OrderProduct op)
            {
                OrderProductId = op.OrderProductId;
                OrderId = op.OrderId;
                ProductId = op.ProductId;
                KonsolId = op.KonsolId;
                Antal = op.Antal;
                Order = new OrderDTO();
                Konsol = new KonsolDTO();
                Product = new ProductDTO();

            }
            [DataMember]
            public int OrderProductId { get; set; }
            [DataMember]
            public int OrderId { get; set; }
            [DataMember]
            public int ProductId { get; set; }
            [DataMember]
            public int KonsolId { get; set; }
            public int Antal { get; set; }

            [DataMember]
            public virtual OrderDTO Order { get; set; }
            [DataMember]
            public virtual ProductDTO Product { get; set; }
            [DataMember]
            public virtual KonsolDTO Konsol { get; set; }

        }
        [DataContract]
        public class KonsolDTO
        {
            public KonsolDTO()
            {
                Products = new HashSet<ProductDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }

            public KonsolDTO(Konsol konsol)
            {
                Id = konsol.Id;
                ConsoleName = konsol.ConsoleName;
                Products = new HashSet<ProductDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
                

            }

            [DataMember]
            public int Id { get; set; }

            [DataMember]
            public string ConsoleName { get; set; }
            [DataMember]
            public virtual ICollection<ProductDTO> Products { get; set; }
            [DataMember]
            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }
        }
        [DataContract]
        public class ProductDTO
        {
            public ProductDTO()
            {
                Genres = new HashSet<GenreDTO>();
                Konsols = new HashSet<KonsolDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }

            public ProductDTO(Product product)
            {
                Id = product.Id;
                ProductName = product.ProductName;
                YearOfRelease = product.YearOfRelease;
                PicLocation = product.PicLocation;
                Genres = new HashSet<GenreDTO>();
                Konsols = new HashSet<KonsolDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string ProductName { get; set; }
            [DataMember]
            public int YearOfRelease { get; set; }
            [DataMember]
            public string PicLocation { get; set; }

            [DataMember]
            public virtual ICollection<GenreDTO> Genres { get; set; }
            [DataMember]
            public virtual ICollection<KonsolDTO> Konsols { get; set; }
            [DataMember]
            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }

        }
        [DataContract]
        public class GenreDTO
        {
            public GenreDTO()
            {
                Products = new HashSet<ProductDTO>();
            }

            public GenreDTO(Genre genre)
            {
                Id = genre.Id;
                GenreName = genre.GenreName;
                Products = new HashSet<ProductDTO>();
            }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string GenreName { get; set; }
            [DataMember]
            public virtual ICollection<ProductDTO> Products { get; set; }
        }

    }
}
