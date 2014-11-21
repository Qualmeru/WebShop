using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
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
