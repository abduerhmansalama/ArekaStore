using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApplication2.Models
{

    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        
        public string Imagepath { get; set; }
        [ForeignKey("Category")]
        public int? SubCat_ID { get; set; }
        public Category MyCategory { get; set; }
        public List<Category> MyCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
