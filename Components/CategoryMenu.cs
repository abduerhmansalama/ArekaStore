using WebApplication2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly FurnitureDBContext _appDbContext;

        public CategoryMenu(FurnitureDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories.Where(x => x.SubCat_ID == null).ToList();

        public IViewComponentResult Invoke()
        {
           // var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.Name);
             var catVms = new List<CatVM>();
                foreach (var item in Categories)
                {
                    var parent = new CatVM { Id = item.ID, Name = item.Name ,SubCat=new List<CatVM>() };

                    var subcats = _appDbContext.Categories.Where(x => x.SubCat_ID == item.ID).ToList();
                    foreach (var subcat in subcats)
                    {
                   
                        parent.SubCat.Add(new CatVM { Id = subcat.ID, Name = subcat.Name, SubCat = null });

                    }
                catVms.Add(parent);
            }
              
           
            return View(catVms);
        }
    }
}
