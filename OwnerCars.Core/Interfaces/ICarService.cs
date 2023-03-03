using OwnerCars.Core.DTO;

namespace OwnerCars.Core.Interfaces
{
    public interface ICarService
    {
        CarDTO GetCar(int id);
        void DeleteCar(int id);
        void AddCar(CarDTO car);
        IEnumerable<CarDTO> GetCars();
        IEnumerable<OwnerDTO> GetOwners();
        void Update(CarDTO car);
        void Dispose();
    }
}
