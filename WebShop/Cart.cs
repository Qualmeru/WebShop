using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Cart
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        [Key,Column(Order = 2)]
        public string KeyToken { get; set; }
        public int ProductId { get; set; }
        public int KonsoleId { get; set; }
        public int GenreId { get; set; }
        public int Antal { get; set; }
        public int UserId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Konsol Konsol { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
