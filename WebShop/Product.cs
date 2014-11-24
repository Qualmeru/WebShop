using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Product
    {
        public Product()
        {
            Genres = new HashSet<Genre>();
            Konsols = new HashSet<Konsol>();
            OrderProduct = new HashSet<OrderProduct>();
        }
        public int Id { get; set; }
        [Required]
        [Column("Product_name")]
        public string ProductName { get; set; }
        [Column("Year_of_release")]
        public int YearOfRelease { get; set; }
        [Column("Pic_location")]
        public string PicLocation { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Konsol> Konsols { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
