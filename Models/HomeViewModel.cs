using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Product> TopSellers { get; set; }
        public IEnumerable<Product> Tabels { get; set; }
        public IEnumerable<Product> Beds { get; set; }
        public IEnumerable<Product> Seating { get; set; }

    }
    
}
