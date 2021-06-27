
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Models
{
    public class CategoryRepo : ICategoryRepository
    {
        private readonly FurnitureDBContext _appDbContext;

        public CategoryRepo(FurnitureDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        List<CatVM> ICategoryRepository.getAllGatWithsu => throw new NotImplementedException();

       
    }
    

}


