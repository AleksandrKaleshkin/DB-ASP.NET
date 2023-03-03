using OwnerCars.Core.DTO;

namespace OwnerCars.Core.Interfaces
{
    public interface IOwnerService
    {
        OwnerDTO GetOwner(int id);
        void DeleteOwner(int id);
        void AddOwner(OwnerDTO owner);
        IEnumerable<OwnerDTO> GetOwners();
        void Update(OwnerDTO owner);
        void Dispose();
    }
}
