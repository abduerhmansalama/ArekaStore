using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
       
        public IActionResult Checkout(int totalPrice,List<Product> products)
        {
            ViewBag.toalprice = totalPrice;
            ViewBag.products = products;
            HttpContext.Session.SetInt32("TotalPrice", totalPrice);

            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
              
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOut","Payment");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {

            ViewBag.CheckoutCompleteMessage = "Thank you for your order.";
            return View();
        }
    }
}
