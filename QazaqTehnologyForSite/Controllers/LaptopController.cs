using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QazaqTehnologyForSite.Models;
using QazaqTehnologyForSite.Models.Laptops;

namespace QazaqTehnologyForSite.Controllers
{
    public class LaptopController : Controller
    {
        private ApplicationContext _db;
        
        public LaptopController(ApplicationContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Laptops.ToListAsync());
        }
        public IActionResult CreateLaptop()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLaptop(Laptop laptop)
        {
            _db.Laptops.Add(laptop);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> CreateProcessor(Processor processor)
        {
            _db.Processors.Add(processor);
            await _db.SaveChangesAsync();
            return RedirectToAction("CreateLaptop");
        }
        
     
        public IActionResult CreateLap()
        {
            Laptop lap = new Laptop();
            lap.Name = "dfsfsf ";
            _db.Laptops.Add(lap);
            _db.SaveChanges();
            return View();
        }
    }
}