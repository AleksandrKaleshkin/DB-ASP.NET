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
        public IActionResult Index()
        {
            return View(carRespository.GetOwnerList());
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
