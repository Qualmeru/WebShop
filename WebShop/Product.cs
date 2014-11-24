using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
