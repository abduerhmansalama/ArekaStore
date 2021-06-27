using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Areas.Identity.Data;

namespace WebApplication2.Models
{
    public class ShoppingProduct
    {
        public int ID { get; set; }
        [ForeignKey("UsingIdentityUser")]
        public string UserID { get; set; }
        [ForeignKey("Product")]

        public int ProductID { get; set; }
        public int Amount { get; set; }
        public UsingIdentityUser  usingIdentity { get; set; }
        public Product product { get; set; }
    }

}
