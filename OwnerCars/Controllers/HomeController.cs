using Microsoft.AspNetCore.Mvc;
using OwnerCars.Data;
using OwnerCars.Models;
using System.Diagnostics;

namespace OwnerCars.Controllers
{
    public class HomeController : Controller
    {


        private readonly CarDealershipsContext context;

        public HomeController(CarDealershipsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Owners);
        }

    }
}