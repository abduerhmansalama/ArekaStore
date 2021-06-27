using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class OrderV2Controller : Controller
    {
        private readonly FurnitureDBContext _furnitureDBContext;
        //private Order order;
        public OrderV2Controller(FurnitureDBContext furnitureDBContext)
        {
            _furnitureDBContext = furnitureDBContext;
        }


        public IActionResult Index(double TotalPrice, double total, double discount)
        {
            OrderModel orderModel = new OrderModel();

            var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            orderModel.shoppingProducts = _furnitureDBContext.ShoppingProducts.Where(i => i.UserID == UserID).Include(i => i.product).ToList();
            orderModel.Total = total;
            orderModel.TotalPrice = TotalPrice;
            orderModel.Discount = discount;
            
            return View(orderModel);
        }
        public IActionResult OrderComplete()
        {
            return View();
        }
        public IActionResult Test(Order order,double totalprice)

        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Order newOrder = new Order()
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                City = order.City,
                State = order.State,
                IdIdentity = userId,
                TotalPrice = totalprice
            };
            orderDetails orderDetails = new orderDetails() { 
                
                TotalPrice = totalprice,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                City = order.City,
                State = order.State,
                IdIdentity = userId,
                
            };
            return RedirectToAction("CheckOut","Payment",orderDetails);
        }

        public IActionResult SubmitOrder(string fname,string lname,string PhoneNumber,string Address ,string City,string State,double TotalPrice)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var allProduct = _furnitureDBContext.ShoppingProducts.Where(i => i.UserID == userId).Include(i => i.product).ToList();
            Order order1 = new Order()
            {
                FirstName = fname,
                LastName = lname,
                PhoneNumber = PhoneNumber,
                Address = Address,
                City =City,
                State = State,
                IdIdentity = userId,
                TotalPrice = TotalPrice
            };
      

            OrderProduct orderProduct = null;

            foreach (var item in allProduct)
            {

                orderProduct = new OrderProduct()
                {
                    ProductId = item.ProductID,

                    Amount = item.Amount
                };
                _furnitureDBContext.orderProducts.Add(orderProduct);

                var productitem = _furnitureDBContext.Products.FirstOrDefault(i => i.ID == item.ProductID);
                productitem.Count -= item.Amount;
                _furnitureDBContext.Update(productitem);
                _furnitureDBContext.Remove(item);
            };

            _furnitureDBContext.Orders.Add(order1);

            _furnitureDBContext.SaveChanges();
            return RedirectToAction("OrderComplete", "OrderV2");
        }
    }

    public class OrderModel
    {
        public List<ShoppingProduct> shoppingProducts { get; set; }
        public double Total { get; set; }
        
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
    }
    public class orderDetails
    {
        public double TotalPrice { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string IdIdentity { get; set; }
  

    }
}
