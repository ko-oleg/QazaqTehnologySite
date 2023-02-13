using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QazaqTehnologyForSite.Models;
using QazaqTehnologyForSite.Models.Laptops;

namespace QazaqTehnologyForSite.Controllers
{
    [Route("/api/[controller]")]
    public class LaptopController : Controller
    {
        private ApplicationContext _db;
        
        public LaptopController(ApplicationContext context)
        {
            _db = context;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _db.Laptops.ToListAsync());
        }
        [HttpGet("GoToCreateProcessor")]
        public RedirectToActionResult GoToCreateProcessor()
        {
            return RedirectToAction("CreateProcessor");
        }
        [HttpGet("GoToViewAllProcessors")]
        public RedirectToActionResult GoToViewAllProcessors()
        {
            return RedirectToAction("ViewAllProcessors");
        }
        [HttpGet("CreateLaptop")]
        public IActionResult CreateLaptop()
        {
            return View();
        }
        [HttpPost("CreateLaptop")]
        public async Task<IActionResult> CreateLaptop(Laptop laptop, Processor processor)
        {
            laptop.Processor = processor;
            _db.Laptops.Add(laptop);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet("CreateProcessor")]
        public IActionResult CreateProcessor()
        {
            return View();
        }
        [HttpPost("CreateProcessor")]
        public async Task<IActionResult> CreateProcessor(Processor processor)
        {
            _db.Processors.Add(processor);
            await _db.SaveChangesAsync();
            return RedirectToAction("CreateLaptop");
        }
        [HttpGet("ViewAllProcessors")]
        public async Task<IActionResult> ViewAllProcessors()
        {
            return View(await _db.Processors.ToListAsync());
        }
        
        [HttpPost("ChooseProcessor")]
        public async Task<IActionResult> ChooseProcessor(Processor processor)
        {
           await CreateLaptop(null, processor);
           return RedirectToAction("CreateLaptop");
        }
            
    }
}