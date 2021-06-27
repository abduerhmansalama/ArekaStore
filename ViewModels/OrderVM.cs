using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
    public class OrderVM
    {
        public ShoppingcartViewModel shoppingCart { get; set; }
        public Order order { get; set; }
    }
}
