using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
using OwnerCars.DataBase.Repositories;
using OwnerCars.Models;

namespace OwnerCars.Api.Controllers
{
    public class CarController : Controller
    {
        CarRepository carRespository;
        public CarController(CarDealershipsContext context)
        {
            this.carRespository = new CarRepository(context);
        }



        [HttpGet]
        public IActionResult Index(string stateOrder, int page =1)
        {
            switch (stateOrder)
            {
                case "BrandSort":
                    carRespository.Sort("BrandSort");
                    break;
                case "ModelSort":
                    carRespository.Sort("ModelSort");
                    break;
                case "YearSort":
                    carRespository.Sort("YearSort");
                    break;
                case "PowerSort":
                    carRespository.Sort("PowerSort");
                    break;
                case "OwnerSort":
                    carRespository.Sort("OwnerSort");
                    break;
            }

            return View(carRespository.GetOwnerList(page));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            carRespository.Add(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            carRespository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            if (carRespository.GetCar(id) != null)
            {
                return View(carRespository.GetCar(id));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            carRespository.Update(car);
            return RedirectToAction("Index");
        }

    }
}
