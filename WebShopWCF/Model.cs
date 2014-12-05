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
                Admins = (Admin)u.Admins;
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
                     LastName = this.LastName,
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

            public Order GetDatabaseOrder()
            {
                return new Order()
                {
                    Id = this.Id,
                    PersonId = this.PersonId,
                    KeyToken = this.KeyToken
                    
                };
            }
            public OrderDTO(Order order)
            {
                Id = order.Id;
                PersonId = order.PersonId;
                KeyToken = order.KeyToken;
                Person = new PersonDTO();
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int PersonId { get; set; }
            [DataMember]
            public string KeyToken { get; set; }
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

            public OrderProduct GetDataBaseOrderProduct()
            {
                return new OrderProduct()
                {
                    Antal = this.Antal,
                    KonsolId = this.KonsolId,
                    OrderId = this.OrderId,
                    OrderProductId = this.OrderProductId

                };
            }
           [DataMember]
            public int OrderProductId { get; set; }
            [DataMember]
            public int OrderId { get; set; }
            [DataMember]
            public int ProductId { get; set; }
            [DataMember]
            public int KonsolId { get; set; }
            [DataMember]
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
            public Konsol ToDB()
            {
                return new Konsol
                {
                    ConsoleName = this.ConsoleName,
                    Id = this.Id


                };
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
                Price = product.Price;
                Genres = new HashSet<GenreDTO>();
                Konsols = new HashSet<KonsolDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            public Product GetDataBaseProduct()
            {
                return new Product()
                {
                    ProductName = this.ProductName,
                    Price = this.Price,
                    YearOfRelease = this.YearOfRelease,
                    PicLocation = this.PicLocation,

                };
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
            public double Price { get; set; }

            [DataMember]
            public  ICollection<GenreDTO> Genres { get; set; }
            [DataMember]
            public  ICollection<KonsolDTO> Konsols { get; set; }
            [DataMember]
            public  ICollection<OrderProductDTO> OrderProduct { get; set; }

        }
        [DataContract]
        public class CartDTO
        {
            public Cart GetCartFromdb()
            {
                return new Cart()
                {
                    Id = Id,
                    Antal = Antal,
                    KeyToken = KeyToken,
                    GenreId = GenreId,
                    KonsoleId = KonsoleId,
                    ProductId = ProductId,
                    UserId = UserId,
                };
            }
            public CartDTO(Cart Cart)
            {
                Id = Cart.Id;
                KeyToken = Cart.KeyToken;
                ProductId = Cart.ProductId;
                KonsoleId = Cart.KonsoleId;
                GenreId = Cart.GenreId;
                UserId = Cart.UserId.Value;

            }

            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string KeyToken { get; set; }
            [DataMember]
            public int ProductId { get; set; }
            [DataMember]
            public int KonsoleId { get; set; }
            [DataMember]
            public int GenreId { get; set; }
            [DataMember]
            public int Antal { get; set; }
            [DataMember]
            public int UserId { get; set; }
            [DataMember]
            public virtual Product Product { get; set; }

            [DataMember]
            public virtual Konsol Konsol { get; set; }
            [DataMember]
            public virtual Genre Genre { get; set; }
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
            public Genre ToDb()
            {
                return new Genre
                {
                    GenreName = this.GenreName,
                    Id = this.Id

                };
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
