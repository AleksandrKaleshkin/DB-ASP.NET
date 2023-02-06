using Microsoft.AspNetCore.Mvc;
using OwnerCars.Data;
using OwnerCars.Models;
using System.Diagnostics;

namespace OwnerCars.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}