using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OwnerCars.Common.Models;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Interfaces;
using OwnerCars.Core.Models;

using OwnerCars.Models;



namespace OwnerCars.Controllers
{
    public class OwnerController : Controller
    {
        IOwnerService ownerService;
        public OwnerController(IOwnerService serv)
        {
            ownerService = serv;
        }


        public IActionResult Views(string name, string surname, int age, SortStateOwner stateOrder, int page = 1)
        {
            int pageSize = 4;

            IEnumerable<OwnerDTO> owners = ownerService.GetOwners();

            if (!string.IsNullOrEmpty(name))
            {
                owners = owners.Where(p => p.Name.ToLower()!.Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                owners = owners.Where(p => p.SurName.ToLower()!.Contains(surname.ToLower()));
            }
            if (age != 0 && age >= 1)
            {
                owners = owners.Where(p => p.Age == age);
            }

            switch (stateOrder)
            {
                case SortStateOwner.NameDesc:
                    owners = owners.OrderByDescending(x => x.Name);
                    break;
                case SortStateOwner.SurNameAsc:
                    owners = owners.OrderBy(x => x.SurName);
                    break;
                case SortStateOwner.SurNameDesc:
                    owners = owners.OrderByDescending(x => x.SurName);
                    break;
                case SortStateOwner.AgeAsc:
                    owners = owners.OrderBy(x => x.Age);
                    break;
                case SortStateOwner.AgeDesc:
                    owners = owners.OrderByDescending(x => x.Age);
                    break;
                default:
                    owners = owners.OrderBy(x => x.Name);
                    break;
            }


            var count = owners.Count();
            IEnumerable<OwnerDTO> items = owners.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            OwnerViewModel ownerView = new OwnerViewModel
            {
                owners= items,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortOwnerViewModel(stateOrder),
                FilterViewModel = new FilterOwnerViewModel(name, surname, age)
            };

            return View(ownerView);
        }


    


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditOwner(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            OwnerDTO owner = ownerService.GetOwner(id);
            if (owner != null)
            {
                return View(owner);
            }
            return NotFound();

        }



        [HttpPost]
        public IActionResult EditOwner(OwnerDTO owner)
        {
            ownerService.Update(owner);
            return RedirectToAction("Views");
        }



        [HttpPost]
        public IActionResult Create(OwnerDTO owner)
        {
            ownerService.AddOwner(owner);
            return RedirectToAction("Views");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ownerService.DeleteOwner(id);
            return RedirectToAction("Views");
        }


    }
}

