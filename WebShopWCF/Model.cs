using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopWCF
{
    public class Model
    {
        public class PersonDTO
        {
            public PersonDTO()
            {
                Order = new HashSet<OrderDTO>();
            }
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
            public virtual ICollection<OrderDTO> Order { get; set; }

        }

        public class OrderDTO
        {
            public OrderDTO()
            {
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            public int Id { get; set; }
            public int PersonId { get; set; }


            public virtual PersonDTO Person { get; set; }

            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }
        }
        public class OrderProductDTO
        {

            public int OrderProductId { get; set; }

            public int OrderId { get; set; }

            public int ProductId { get; set; }
            public int KonsolId { get; set; }
            public int Antal { get; set; }


            public virtual OrderDTO Order { get; set; }

            public virtual ProductDTO Product { get; set; }

            public virtual KonsolDTO Konsol { get; set; }

        }
        public class KonsolDTO
        {
            public KonsolDTO()
            {
                Products = new HashSet<ProductDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }


            public int Id { get; set; }


            public string ConsoleName { get; set; }

            public virtual ICollection<ProductDTO> Products { get; set; }
            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }
        }

        public class ProductDTO
        {
            public ProductDTO()
            {
                Genres = new HashSet<GenreDTO>();
                Konsols = new HashSet<KonsolDTO>();
                OrderProduct = new HashSet<OrderProductDTO>();
            }
            public int Id { get; set; }
            public string ProductName { get; set; }
            public int YearOfRelease { get; set; }
            public string PicLocation { get; set; }

            public virtual ICollection<GenreDTO> Genres { get; set; }
            public virtual ICollection<KonsolDTO> Konsols { get; set; }
            public virtual ICollection<OrderProductDTO> OrderProduct { get; set; }

        }
        public class GenreDTO
        {
            public GenreDTO()
            {
                Products = new HashSet<ProductDTO>();
            }

            public int Id { get; set; }

            public string GenreName { get; set; }

            public virtual ICollection<ProductDTO> Products { get; set; }
        }

    }
}
