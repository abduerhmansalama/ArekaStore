using WebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class ShoppingcartViewModel
    { 
        public ShoppingCart shoppingcart { get; set;}
        public decimal shoppingcartTotal { get; set;}
    }
}
