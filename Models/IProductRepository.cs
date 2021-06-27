using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct { get; }
       
    }
}
