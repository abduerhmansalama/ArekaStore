using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    public class ShoppingCartController :Controller
    {
        private readonly IProductRepository _furntrieRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IProductRepository furntrieRepository, ShoppingCart shoppingCart)
            {
            _furntrieRepository = furntrieRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppingcartViewModel
            {
                shoppingcart = _shoppingCart,
                shoppingcartTotal = _shoppingCart.GetShoppingCartTotal()
                };
            return View(shoppingCartViewModel);
        }
        [Authorize(Roles ="User")]
        public RedirectToActionResult AddToShoppingCart(int furntireId)
        {
            var Selectedfurntire = _furntrieRepository.GetAllProduct.FirstOrDefault(c => c.ID == furntireId);
            if(Selectedfurntire !=null)
            {
                _shoppingCart.AddToCart(Selectedfurntire, 1);
            }
            return RedirectToAction("Index");
        }
        
        public RedirectToActionResult RemoveFromShoppingCart(int furntireId)
        {
            var Selectedfurntire = _furntrieRepository.GetAllProduct.FirstOrDefault(c => c.ID == furntireId);
            if (Selectedfurntire != null)
            {
                _shoppingCart.Removefromcart(Selectedfurntire);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
