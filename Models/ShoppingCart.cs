using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class ShoppingCart
    {
        private readonly FurnitureDBContext appDbcontext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }
        public ShoppingCart(FurnitureDBContext appDbcontext)
        {
            this.appDbcontext = appDbcontext;
        }
        public static ShoppingCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var Context = service.GetService<FurnitureDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(Context) { ShoppingCartId = cartId };
        }
        public void AddToCart(Product furntire, int amount)
        {
            var ShoppingCartItem = appDbcontext.ShoppingCartItems.SingleOrDefault(s => s.furntire.ID == furntire.ID && s.ShoppingCartId
            == ShoppingCartId);
            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    furntire = furntire,
                     Amount= amount
                };
                appDbcontext.ShoppingCartItems.Add(ShoppingCartItem);

            }
            else
            {
                ShoppingCartItem.Amount++;
            }
            appDbcontext.SaveChanges();
        }
        public int Removefromcart(Product furntire)
        {
            var ShoppingCartItem = appDbcontext.ShoppingCartItems.SingleOrDefault(s => s.furntire.ID == furntire.ID && s.ShoppingCartId
           == ShoppingCartId);
            var localAmount = 0;
            if(ShoppingCartItem != null)
            {
                if(ShoppingCartItem.Amount>1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    appDbcontext.ShoppingCartItems.Remove(ShoppingCartItem);
                }
         
         }
            appDbcontext.SaveChanges();
             return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems=appDbcontext.ShoppingCartItems.Where(c =>c.ShoppingCartId
            == ShoppingCartId)
                .Include(s => s.furntire)
                .ToList());
        }
        public void ClearCart()
        {
            var CartItem = appDbcontext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
                appDbcontext.ShoppingCartItems.RemoveRange(CartItem);
            appDbcontext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            var Total =  appDbcontext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
             .Select(c => c.furntire.Price * c.Amount).Sum();
            return Total;
        }
    }
}
