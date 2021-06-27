using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class Offer
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }
        [Required]

        public string Discription { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
