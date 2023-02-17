
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
using OwnerCars.Models;

namespace OwnerCars.DataBase.Repositories
{
    public class CarRepository
    {
        private CarDealershipsContext db;
        static SortStateCar sortcar;

        public CarRepository(CarDealershipsContext db)
        {
            this.db = db;
        }

        public SortStateCar Sort(string state)
        {
            switch (state)
            {
                case "BrandSort":
                    sortcar = sortcar == SortStateCar.BrandAsc ? SortStateCar.BrandDesc : SortStateCar.BrandAsc;
                    break;
                case "ModelSort":
                    sortcar = sortcar == SortStateCar.ModelAsc ? SortStateCar.ModelDesc : SortStateCar.ModelAsc;
                    break;
                case "YearSort":
                    sortcar = sortcar == SortStateCar.YearAsc ? SortStateCar.YearDesc : SortStateCar.YearAsc;
                    break;
                case "PowerSort":
                    sortcar = sortcar == SortStateCar.PowerAsc ? SortStateCar.PowerDesc : SortStateCar.PowerAsc;
                    break;
                case "OwnerSort":
                    sortcar = sortcar == SortStateCar.OwnerAsc ? SortStateCar.OwnerDesc : SortStateCar.OwnerAsc;
                    break;
                default:
                    sortcar = SortStateCar.BrandAsc;
                    break;
            }
            return sortcar;
        }


        public CarViewModel GetOwnerList(int page =1)
        {

            int pageSize = 4;
            IEnumerable<Car> cars = db.Cars.Include(x=> x.Owner);

            cars = sortcar switch
            {

                SortStateCar.BrandDesc => cars.OrderByDescending(x => x.Brand),
                SortStateCar.ModelAsc => cars.OrderBy(x => x.Model),
                SortStateCar.ModelDesc => cars.OrderByDescending(x => x.Model),
                SortStateCar.YearAsc => cars.OrderBy(x => x.Year),
                SortStateCar.YearDesc => cars.OrderByDescending(x => x.Year),
                SortStateCar.PowerAsc => cars.OrderBy(x => x.Power),
                SortStateCar.PowerDesc => cars.OrderByDescending(x => x.Power),
                SortStateCar.OwnerAsc => cars.OrderBy(x => x.Owner.Name),
                SortStateCar.OwnerDesc => cars.OrderByDescending(x => x.Owner.Name),
                _ => cars.OrderBy(x => x.Brand)
            };

            var count = cars.Count();
            IEnumerable<Car> items = cars.Skip((page-1)*pageSize).Take(pageSize).ToList();

            PageViewModel pageView = new PageViewModel (count, page, pageSize);



            CarViewModel viewModel = new CarViewModel
            {
                PageViewModel = pageView,
                Cars = items
            };

            return viewModel;
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
