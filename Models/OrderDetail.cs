using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public int Amount { get; set; }
        public Product product { get; set; }
        public Order Order { get; set; }
    }
}
