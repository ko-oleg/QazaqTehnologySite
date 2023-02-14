using System;
using System.Linq;
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
        //GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
        
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
        
        [HttpGet("ViewAllProcessors")]
        public async Task<IActionResult> ViewAllProcessors()
        {
            return View(await _db.Processors.ToListAsync());
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _db.Laptops.ToListAsync());
        }
        
        [HttpGet("CreateLaptop")]
        public IActionResult CreateLaptop()
        {
            return View();
        }
        [HttpPost("CreateLaptop")]
        public async Task<IActionResult> CreateLaptop(Laptop laptop)
        {
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
            return Ok();
        }
        
        [HttpPost("TakeProcessorsIdForLaptop")]
        public IActionResult TakeProcessorsIdForLaptop(int idLaptop,int idProc)
        {
            var includProc = _db.Processors.SingleOrDefault(p => p.Id == idProc);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Processors.Add(includProc);
            _db.SaveChanges();
            return Ok();
        }
        
    }
}