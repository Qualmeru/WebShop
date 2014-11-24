using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        }
        [DataContract]
        public class OrderDTO
        {
            public OrderDTO()
            {
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
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string GenreName { get; set; }
            [DataMember]
            public virtual ICollection<ProductDTO> Products { get; set; }
        }

    }
}
