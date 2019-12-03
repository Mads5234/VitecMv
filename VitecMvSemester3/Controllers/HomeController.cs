using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VitecMvSemester3.Models;

namespace VitecMvSemester3.Controllers
{
    public class HomeController : Controller
    {
        //--------Logger start--------
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult index()
        {
            _logger.LogInformation("Log message in the Index() method");
            return View();
        }
        public IActionResult privacy()
        {
            _logger.LogInformation("Log message in the Privacy() method");
            return View();
        }
        //------Logger slut--------

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
