using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

//namespace WebApplication2.Models
//{
//    public class OrderRepository : IOrderRepository
//    {
//        private readonly FurnitureDBContext _appDbContext;
//        private readonly ShoppingCart _shoppingCart;

//        public OrderRepository(FurnitureDBContext appDbContext, ShoppingCart shoppingCart)
//        {
//            _appDbContext = appDbContext;
//            _shoppingCart = shoppingCart;
//        }

//        public void CreateOrder(Order order)
//        {
//            order.OrderPlaced = DateTime.Now;
//            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
//            _appDbContext.Orders.Add(order);
//            _appDbContext.SaveChanges();

//            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

//            foreach(var shoppingCartItem in shoppingCartItems)
//            {
//                var orderDetail = new OrderDetail
//                {
//                    Amount = shoppingCartItem.Amount,
//                    Price = shoppingCartItem.furntire.Price,
//                    ProductId = shoppingCartItem.furntire.ID,
//                    OrderId = order.OrderId
//                };

//                _appDbContext.OrderDetails.Add(orderDetail);
//            }

//            _appDbContext.SaveChanges();
//        }
//    }
//}
