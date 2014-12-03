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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string KeyToken { get; set; }
        public int ProductId { get; set; }
        public int KonsoleId { get; set; }
        public int GenreId { get; set; }
        public int Antal { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("KonsoleId")]
        public virtual Konsol Konsol { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
