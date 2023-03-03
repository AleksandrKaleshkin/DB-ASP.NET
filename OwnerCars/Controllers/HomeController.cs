using Microsoft.AspNetCore.Mvc;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
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

        [HttpGet]
        public new IActionResult ViewData()
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult CreateData() 
        {
            return View();
        }


    }
}