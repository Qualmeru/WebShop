using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    [Table("Console")]
    public class Konsol
    {
        public Konsol()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Console_name")]
        public string ConsoleName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
