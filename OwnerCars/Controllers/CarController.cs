using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OwnerCars.Common.Models;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Interfaces;
using OwnerCars.Core.Models;
using OwnerCars.DataBase.Models;
using OwnerCars.DataBase.Repositories;
using OwnerCars.Models;

namespace OwnerCars.Api.Controllers
{
    public class CarController : Controller
    {
        readonly ICarService carService;


        public CarController(ICarService serv)
        {
            carService= serv;
        }



        [HttpGet]
        public IActionResult Index(int? owner, string? brand, SortStateCar stateOrder = SortStateCar.BrandAsc, int page =1)
        {
            int pageSize = 4;
            IEnumerable<CarDTO> cars = carService.GetCars();
            IEnumerable<OwnerDTO> owners = carService.GetOwners();

            if (owner != null && owner != 0)
            {
                cars = cars.Where(p => p.OwnerId == owner);
            }
            if (!string.IsNullOrEmpty(brand))
            {

                cars = cars.Where(p => p.Brand.ToLower()!.Contains(brand.ToLower()));
            }

            switch (stateOrder)
            {
                case SortStateCar.BrandDesc:
                    cars = cars.OrderByDescending(x => x.Brand);
                    break;
                case SortStateCar.ModelAsc:
                    cars = cars.OrderBy(x => x.Model);
                    break;
                case SortStateCar.ModelDesc:
                    cars = cars.OrderByDescending(x => x.Model);
                    break;
                case SortStateCar.YearAsc:
                    cars = cars.OrderBy(x => x.Year);
                    break;
                case SortStateCar.YearDesc:
                    cars = cars.OrderByDescending(x => x.Year);
                    break;
                case SortStateCar.PowerAsc:
                    cars = cars.OrderBy(x => x.Power);
                    break;
                case SortStateCar.PowerDesc:
                    cars = cars.OrderByDescending(x => x.Power);
                    break;
                case SortStateCar.OwnerAsc:
                    cars = cars.OrderBy(x => x.Owner.Name);
                    break;
                case SortStateCar.OwnerDesc:
                    cars = cars.OrderByDescending(x => x.Owner.Name);
                    break;
                default:
                    cars = cars.OrderBy(x => x.Brand);
                    break;
            }
            var count = cars.Count();
            IEnumerable<CarDTO> items = cars.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            CarViewModel viewModel = new()
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterCarViewModel(owners.ToList(), brand, owner),
                SortViewModel = new SortCarViewModel(stateOrder),
                Cars = items
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarDTO car)
        {
            if (ModelState.IsValid)
            {
                carService.AddCar(car);
                return RedirectToAction("Index");
            }
            else
            {
                return View(car);
            }
        }


        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            carService.DeleteCar(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (carService.GetCar(id) != null)
            {
                return View(carService.GetCar(id));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CarDTO car)
        {
            carService.Update(car);
            return RedirectToAction("Index");
        }
        
    }
}
