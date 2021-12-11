using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using chefsdishes.Models;
using Microsoft.EntityFrameworkCore;

namespace chefsdishes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }


// ____________________
// render view all chefs here
// __________________
        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs.OrderByDescending(d => d.CreatedAt).Include(a => a.myDishes).ToList();
            return View();
        }

// ____________________
//render view chef's dishes here
// __________________
        [HttpGet("viewchefsDishes")]
        public IActionResult ViewDishes()
        {
            ViewBag.AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).Include(b => b.myChef).ToList();
            return View();
        }
// ____________________
// render view add chef page
// __________________
        [HttpGet("addchef")]
        public IActionResult AddChef()
        {
            return View();
        }
// ____________________
// create new chef info here
// __________________
        [HttpPost("newChef")]
        public IActionResult newChef(Chef addedChef)
        {
            if(ModelState.IsValid)
            {
                _context.Add(addedChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View ("AddChef");
            }
        }
// ____________________
// render view add dish page
// __________________
        [HttpGet("addDish")]
        public IActionResult AddDish()
        {
            ViewBag.AllChefs = _context.Chefs.Include(a => a.myDishes).ToList();
            return View();
        }
// ____________________
// create new dish info here
// __________________
        [HttpPost("addnewDish")]
        public IActionResult newDish(Dish addedDish)
        {
            if(ModelState.IsValid)
            {
                _context.Add(addedDish);
                _context.SaveChanges();
                return RedirectToAction("ViewDishes");
            } else {
                ViewBag.AllChefs = _context.Chefs.Include(a => a.myDishes).ToList();
                return View ("AddDish");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
