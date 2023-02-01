using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.Models;

namespace OwnerCars.Controllers
{
    public class OwnerController : Controller
    {
        private readonly CarDealershipsContext context;

        public OwnerController(CarDealershipsContext context)
        {
            this.context = context;
        }


        public IActionResult Views()
        {
            return View(context.Owners);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditOwner(int? id) 
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Owner owner = context.Owners.Find(id);
            if (owner != null)
            {
                return View(owner);
            }
            return HttpNotFound();

        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(Owner owner)
        {

            if (ModelState.IsValid) {
                if (owner.Id == default)
                    context.Entry(owner).State = EntityState.Added;
                else
                    context.Entry(owner).State = EntityState.Modified;
                context.SaveChanges();
                return Redirect("/Owner/Views");
            }
            return View(owner);
        }

    }
}
