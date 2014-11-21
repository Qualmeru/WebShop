using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
