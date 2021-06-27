using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart )
        {
            _shoppingCart = shoppingCart;
        }
        public IViewComponentResult Invoke()
        {
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingcartViewModel
            {
                shoppingcart = _shoppingCart,
                shoppingcartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);

        }
    }
}
