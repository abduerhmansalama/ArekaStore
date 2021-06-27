#region Old
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using WebApplication2.Models;

//namespace WebApplication2.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FurnitureDBContext furnitureDB;

        public HomeController(ILogger<HomeController> logger, FurnitureDBContext context)
        {
            _logger = logger;
            furnitureDB = context;

        }

        public IActionResult Index()
        {
            
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                TopSellers = furnitureDB.Products.Where(p => p.Count < 5).Take(4).ToList(),
                Tabels = furnitureDB.Products.Where(p => p.Name.Contains("table")).Take(4).ToList(),
                Beds = furnitureDB.Products.Where(p => p.Name.Contains("bed")).Take(4).ToList(),
                Seating = furnitureDB.Products.Where(p => p.Name.Contains("seat")).Take(4).ToList()

            };


            return View(homeViewModel);
        }

        //public IActionResult ContactUs()
        //{
        //    return View();
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
