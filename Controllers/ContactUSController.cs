using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class ContactUSController : Controller
    {
        private readonly FurnitureDBContext _db;
        public ContactUSController(FurnitureDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Send(Contact_Us contact_)
        {
            Contact_Us contact_1 = new Contact_Us();
            contact_1.ID = contact_.ID;
            contact_1.Email = contact_.Email;
            contact_1.Name = contact_.Name;
            contact_1.Phone = contact_.Phone;
            contact_1.Message = contact_.Message;
            _db.Contact_Uss.Add(contact_1);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
