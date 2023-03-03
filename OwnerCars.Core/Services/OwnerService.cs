using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OwnerCars.Common.Models;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Infrastructure;
using OwnerCars.Core.Interfaces;
using OwnerCars.Core.Models;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Models;


namespace OwnerCars.Core.Services
{
    public class OwnerService : IOwnerService
    {
        IUnitOfWork DataBase { get; set; }

        public OwnerService(IUnitOfWork unit)
        {
            DataBase = unit;
        }

        public void AddOwner(OwnerDTO ownerDto)
        {
            if (ownerDto == null)
            {
                throw new ValidationException("Владелец не найден!", "");
            }
            Owner owner = new Owner
            {
                Name = ownerDto.Name,
                SurName = ownerDto.SurName,
                Age = ownerDto.Age,
                Email = ownerDto.Email
            };
            DataBase.Owners.Create(owner);
            DataBase.Save();
        }

        public void DeleteOwner(int id)
        {
            if (id == 0)
            {
                throw new ValidationException("Владелец не найден!", "");
            }
            DataBase.Owners.Delete(id);
            DataBase.Save();
        }

        public OwnerDTO GetOwner(int id)
        {
            if (id == 0)
                throw new ValidationException("Владелец не найден!", "");
            var owner = DataBase.Owners.Get(id);
            if (owner==null)
                throw new ValidationException("Владелец не найден!", "");
            return new OwnerDTO { Name = owner.Name,SurName = owner.SurName,Age = owner.Age,Email = owner.Email };

        }

        public IEnumerable<OwnerDTO> GetOwners()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Owner, OwnerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Owner>, List<OwnerDTO>>(DataBase.Owners.GetAll());
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Update(OwnerDTO ownerDto)
        {
            var owner = DataBase.Owners.Get(ownerDto.Id);
            owner.Name= ownerDto.Name;
            owner.SurName= ownerDto.SurName;
            owner.Age= ownerDto.Age;
            owner.Email= ownerDto.Email;
            DataBase.Owners.Update(owner);
            DataBase.Save();
        }
    }
}
