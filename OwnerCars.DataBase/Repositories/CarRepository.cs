using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using OwnerCars.Data;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Models;

namespace OwnerCars.DataBase.Repositories
{
    public class CarRepository: IRepository<Car>
    {
        private CarDealershipsContext db;

        public CarRepository(CarDealershipsContext db)
        {
            this.db = db;
        }


/*
        public CarViewModel GetOwnerList(int? owner, string? brand, SortStateCar sortState, int page =1)
        {
            int pageSize = 4;
            IEnumerable<Car> cars = db.Cars.Include(x=> x.Owner);

            if (owner!=null && owner!=0)
            {
                cars = cars.Where(p => p.OwnerId == owner);
            }
            if (!string.IsNullOrEmpty(brand))
            {

                cars = cars.Where(p => p.Brand.ToLower()!.Contains(brand.ToLower()));
            }

            switch (sortState)
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
            IEnumerable<Car> items = cars.Skip((page-1)*pageSize).Take(pageSize).ToList();

            CarViewModel viewModel = new CarViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                FilterViewModel = new FilterCarViewModel(db.Owners.ToList(), brand, owner),
                SortViewModel = new SortCarViewModel(sortState),
                Cars= items                   
            };

            return viewModel;
        }
*/

        public IEnumerable<Car> GetAll()
        {
            return db.Cars.Include(o=> o.Owner);
        }

        public Car Get(int id)
        {
            var car = db.Cars.Find(id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        public IEnumerable<Car> find(Func<Car, bool> predicate)
        {
            return db.Cars.Include(o =>o.Owner).Where(predicate).ToList();
        }

        public void Create(Car item)
        {
            item.Owner = db.Owners.Find(item.OwnerId);
            db.Cars.Add(item);
        }

        public void Update(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car? car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }
    }
}
