using AutoMapper;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Interfaces;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Models;
using OwnerCars.Core.Infrastructure;

namespace OwnerCars.Core.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork DataBase { get; set; }

        public CarService(IUnitOfWork unit) 
        {
            DataBase = unit;
        }

        public void AddCar(CarDTO carDto)
        {
            Owner owner = DataBase.Owners.Get(carDto.OwnerId);

            if (owner == null)
            {
                throw new ValidationException("Владелец не найден!", "");
            }
            Car car = new Car
            {
                Brand = carDto.Brand,
                Model = carDto.Model,
                Year = carDto.Year,
                Power = carDto.Power,
                OwnerId = owner.Id
            };
            DataBase.Cars.Create(car);
            DataBase.Save();
        }

        public void DeleteCar(int id)
        {
            if (id == 0)
            {
                throw new ValidationException("Телефон не найден", "");
            }
            DataBase.Cars.Delete(id);
            DataBase.Save();

        }

        public CarDTO GetCar(int id)
        {
            if (id == 0) 
                throw new ValidationException("Автомобиль не найден","");
            var car = DataBase.Cars.Get(id);
            if (car == null)
                throw new ValidationException("Автомобиль не найден", "");

            return new CarDTO { Brand = car.Brand, Model = car.Model, Year = car.Year, Power = car.Power, Owner = car.Owner, OwnerId= car.OwnerId };
        }

        public IEnumerable<CarDTO> GetCars()
        {
            var mapper = new MapperConfiguration(cfg=> cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, List<CarDTO>>(DataBase.Cars.GetAll());
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Update(CarDTO carDto)
        {
            var car = DataBase.Cars.Get(carDto.Id);
            car.Brand = carDto.Brand;
            car.Model = carDto.Model;
            car.Year = carDto.Year;
            car.Power = carDto.Power;
            car.Owner = carDto.Owner;
            car.OwnerId = carDto.OwnerId;
            DataBase.Cars.Update(car);
            DataBase.Save();
        }

        public IEnumerable<OwnerDTO> GetOwners()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Owner, OwnerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Owner>, List<OwnerDTO>>(DataBase.Owners.GetAll());
        }
    }
}
