﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string KeyToken { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

    }
}
