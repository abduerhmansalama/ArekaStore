using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly FurnitureDBContext _appDbContext;

        public ProductRepository(FurnitureDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Product> GetAllProduct 
        { 
           get
            {
                return _appDbContext.Products.Include(c => c.MYCategory);
            }
        }
        public Product GetCandyById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(c => c.ID == productId);
        }
    }
}
