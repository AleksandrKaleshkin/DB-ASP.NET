using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
using OwnerCars.DataBase.Repositories;
using OwnerCars.Models;



namespace OwnerCars.Controllers
{
    public class OwnerController : Controller
    {
        OwnerRepository ownerRespository;
        public OwnerController(CarDealershipsContext context)
        {
            this.ownerRespository = new OwnerRepository(context);
        }


        public IActionResult Views(string? name, string? surname, int age, SortStateOwner stateOrder, int page=1)
        {

            return View(ownerRespository.GetOwnerList(name, surname, age, page, stateOrder));
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditOwner(int id) 
        {
            if (id == null)
            {
                return NotFound();
            }
             Owner owner = ownerRespository.GetOwner(id);
            if (owner != null)
            {
                return View(owner);
            }
            return NotFound();

        }



        [HttpPost]
        public IActionResult EditOwner(Owner owner)
        {
            ownerRespository.Update(owner);
            return RedirectToAction("/Views");
        }



        [HttpPost]
        public IActionResult Create(Owner owner)
        {
                ownerRespository.Add(owner);
            return RedirectToAction("Views");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ownerRespository.Remove(id);
            return RedirectToAction("Views");
        }       
        
    }
        
}
