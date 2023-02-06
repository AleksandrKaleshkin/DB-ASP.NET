using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
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


        public IActionResult Views()
        {
            return View(ownerRespository.GetOwnerList());
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

            if (ModelState.IsValid) {
                ownerRespository.Add(owner);
            }
            return Ok(owner);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ownerRespository.Remove(id);
            return RedirectToAction("Views");
        }       
        
    }
        
}
