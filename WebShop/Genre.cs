using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    class Genre
    {
        public Genre()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }
        [Column("Genre_name")]
        public string GenreName { get; set; }

        public virtual ICollection<Product> Products { get; set; } 
    }
}
