using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class PaymentMethod
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Discription { get; set; }
        public List<Order> Orders { get; set; }
    }
}
