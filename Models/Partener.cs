using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class Partener
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string LogoPath { get; set; }
        [Required]
        public string SiteLink { get; set; }
    }
}
