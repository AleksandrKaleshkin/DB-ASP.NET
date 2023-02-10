
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
using OwnerCars.Models;

namespace OwnerCars.DataBase.Repositories
{
    public class CarRepository
    {
        private CarDealershipsContext db;

        public CarRepository(CarDealershipsContext db)
        {
            this.db = db;
        }

        public IEnumerable<Car> GetOwnerList()
        {
            return db.Cars.ToList();
        }

        public Car GetCar(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        public void Add(Car car)
        {
            car.Owner = db.Owners.Find(car.OwnerId);
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Remove(int id)
        {
            Car? car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
