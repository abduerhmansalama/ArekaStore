using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        private readonly FurnitureDBContext _furnitureDB;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(FurnitureDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _furnitureDB = context;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Show()
        {
            return View();
        }

        public IActionResult ShowProduct()
        {
            return View();
        }
        public IActionResult Search(string str)
        {
            var prod = _furnitureDB.Products.Where(w => w.Discription.ToLower().Contains(str.ToLower())).ToList();

            return View(nameof(Index), prod);
        }
        public IActionResult Index(int id)
        {
            //var MyCategory = _furnitureDB.Categories.Where(c => c.Name == CategoryName).ToList();

            var allproductas = _furnitureDB.Products.Where(p => p.Cat_ID == id).ToList();
            //var all = _furnitureDB.Products.FirstOrDefault(p => p.ID == id);
            //ViewBag.all = allproductas;
            //var all = _furnitureDB.Products.ToList();
            return View(allproductas);
        }
        public IActionResult Details(int id)
        {
            var allproductas = _furnitureDB.Products.SingleOrDefault(P => P.ID == id);
            return View(allproductas);
        }
        public IActionResult CatProduct(int id)
        {
            var cateproducts = _furnitureDB.Products.Where(P => P.Cat_ID == id);
            return View(cateproducts);
        }

        //create new product
        public IActionResult Create()
        {

            SelectList selectLists = new SelectList(_furnitureDB.Categories.Where(w => w.SubCat_ID != null).ToList(), "ID", "Name");
            ViewBag.dataSelect = selectLists;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile img)
        {
            string folderPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string[] arr = img.FileName.Split(".");
            string pathExetention = arr[arr.Length - 1];
            string fileName = Guid.NewGuid().ToString() + "." + pathExetention;
            string filePath = Path.Combine(folderPath, fileName);
            img.CopyTo(new FileStream(filePath, FileMode.Create));
            product.Img_path = fileName;
            if (ModelState.IsValid)
            {

                _furnitureDB.Add(product);
                await _furnitureDB.SaveChangesAsync();
                return RedirectToAction(nameof(GetAll));
            }
            return View(product);
        }
        //Edit product
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _furnitureDB.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            SelectList selectLists = new SelectList(_furnitureDB.Categories.Where(w => w.SubCat_ID != null).ToList(), "ID", "Name");
            ViewBag.dataSelect = selectLists;
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Discount,Color,Count,Fabric,Discription,Brand,Img_path,Cat_ID")] Product product, string imgpath)
        {

            if (id != product.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _furnitureDB.Update(product);
                    product.Img_path = imgpath;
                    await _furnitureDB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetAll));
            }
            return View(product);
        }
        //Delete product
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _furnitureDB.Products
                .FirstOrDefaultAsync(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var prod = await _furnitureDB.Products.FindAsync(id);

            _furnitureDB.Products.Remove(prod);
            await _furnitureDB.SaveChangesAsync();
            return RedirectToAction(nameof(GetAll));
        }
        private bool ProductExists(int iD)
        {
            throw new NotImplementedException();
        }
        //Get All Products To show  For Admin
        public IActionResult GetAll()
        {
            var allProd = _furnitureDB.Products.ToList();
            return View(allProd);
        }

        //Filteration By Discount
        public IActionResult SearchByDiscount(int Cat_id, int Prodisc)
        {
            var allProd = _furnitureDB.Products.Where(p => p.Cat_ID == Cat_id).ToList();
            var prod = allProd.Where(d => d.Discount == Prodisc).ToList();
            return View(nameof(Index), prod);
        }

        //Filteration By Price
        public IActionResult SearchByLessthanprice(int Cat_id, int Prodprice, int prodp)
        {
            var allProd = _furnitureDB.Products.Where(p => p.Cat_ID == Cat_id).ToList();
            var prod = allProd.Where(d => d.Price >= Prodprice && d.Price < prodp).ToList();
            return View(nameof(Index), prod);
        }

        public IActionResult SearchByGreaterThanPrice(int Cat_id, int Prodprice)
        {
            var allProd = _furnitureDB.Products.Where(p => p.Cat_ID == Cat_id).ToList();
            var prod = allProd.Where(d => d.Price >= Prodprice).ToList();
            return View(nameof(Index), prod);
        }
        //Filteration By Brand
        public IActionResult SearchByBrand(int Cat_id, string prodBrand)
        {
            var allProd = _furnitureDB.Products.Where(p => p.Cat_ID == Cat_id).ToList();
            var prod = allProd.Where(d => d.Brand.ToLower() == prodBrand.ToLower()).ToList();
            return View(nameof(Index), prod);
        }
        //Filteration By Color
        public IActionResult SearchByColor(int Cat_id, string prodColor)
        {
            var allProd = _furnitureDB.Products.Where(p => p.Cat_ID == Cat_id).ToList();
            var prod = allProd.Where(d => d.Color.ToLower() == prodColor.ToLower()).ToList();
            return View(nameof(Index), prod);
        }

        // SearchByDiscount Admin
        public IActionResult SearchByDiscountAdmin( int Prodisc)
        {
            var allProd = _furnitureDB.Products.ToList();
            var prod = allProd.Where(d => d.Discount == Prodisc).ToList();
            return View(nameof(GetAll), prod);
        }

        //Filteration By Price Admin
        public IActionResult SearchByLessthanpriceAdmin( int Prodprice, int prodp)
        {
            var allProd = _furnitureDB.Products.ToList();
            var prod = allProd.Where(d => d.Price >= Prodprice && d.Price < prodp).ToList();
            return View(nameof(GetAll), prod);
        }

        public IActionResult SearchByGreaterThanPriceAdmin( int Prodprice)
        {
            var allProd = _furnitureDB.Products.ToList();
            var prod = allProd.Where(d => d.Price >= Prodprice).ToList();
            return View(nameof(GetAll), prod);
        }

        //Filteration By Brand Admin
        public IActionResult SearchByBrandAdmin( string prodBrand)
        {
            var allProd = _furnitureDB.Products.ToList();
            var prod = allProd.Where(d => d.Brand.ToLower() == prodBrand.ToLower()).ToList();
            return View(nameof(GetAll), prod);
        }

        //Filteration By Color Admin    
        public IActionResult SearchByColorAdmin( string prodColor)
        {
            var allProd = _furnitureDB.Products.ToList();
            var prod = allProd.Where(d => d.Color.ToLower() == prodColor.ToLower()).ToList();
            return View(nameof(GetAll), prod);
        }

    }
}
