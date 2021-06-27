using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        [Range(0, 99, ErrorMessage = "enter precentage of discount 0=>100")]
        public int? Discount { get; set; }
        [DataType(DataType.Text)]
        public string Color { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Pleas enter valid number")]
        public int? Count { get; set; }
        [DataType(DataType.MultilineText)]
        public string Fabric { get; set; }
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }
        [DataType(DataType.Text)]
        public string Brand { get; set; }
        public string Img_path { get; set; }
        [ForeignKey("Category")]
        public int? Cat_ID { get; set; }
        public Category MYCategory { get; set; }
        public List<ShoppingProduct> shoppingProducts { get; set; }
        public List<OrderProduct> orderProducts { get; set; }

    }
}
