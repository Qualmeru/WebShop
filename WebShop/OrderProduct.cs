using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class OrderProduct
    {
        [Key,Column(Order=0)]
        public int OrderProductId { get; set; }
        [Key,Column(Order=1)]
        public int OrderId { get; set; }
        [Key,Column(Order=2)]
        public int ProductId { get; set; }
        public int KonsolId { get; set; }
        public int Antal { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("KonsolId")]
        public virtual Konsol Konsol { get; set; }
    }
}
