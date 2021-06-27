using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class User_Product
    {

        [Key]
        public int ID { get; set; }
        public int? RateValue { get; set; }
        [ForeignKey("User")]
        public int? User_id { get; set; }
        [ForeignKey("UsingIdentityUser")]
        public int? IdIdentity { get; set; }
        [ForeignKey("Product")]
        public  int? Product_id { get; set; }

        
    }
}
