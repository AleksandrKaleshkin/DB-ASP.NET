
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Models;

namespace OwnerCars.DataBase.Repositories
{
    public class OwnerRepository: IRepository<Owner>
    {
        private CarDealershipsContext db;
        //static SortStateOwner sortowner;

        public OwnerRepository(CarDealershipsContext db)
        {
            this.db = db;
        }



    
/*
    public OwnerViewModel GetOwnerList(string? name, string? surname,int age, int page =1 , SortStateOwner sortState = SortStateOwner.NameAsc)
        {
            int pageSize = 4;

            IEnumerable<Owner> owners = db.Owners;

            if (!string.IsNullOrEmpty(name))
            {
                owners = owners.Where(p => p.Name.ToLower()!.Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(surname))
            {
                owners = owners.Where(p => p.SurName.ToLower()!.Contains(surname.ToLower()));
            }
            if (age!=null && age>=1)
            {
                owners = owners.Where(p => p.Age == age);
            }

            switch (sortState)
            {
                case SortStateOwner.NameDesc:
                    owners = owners.OrderByDescending(x => x.Name);
                    break;
                case SortStateOwner.SurNameAsc:
                    owners = owners.OrderBy(x => x.SurName);
                    break;
                case SortStateOwner.SurNameDesc:
                    owners = owners.OrderByDescending(x => x.SurName);
                    break;
                case SortStateOwner.AgeAsc:
                    owners = owners.OrderBy(x => x.Age);
                    break;
                case SortStateOwner.AgeDesc:
                    owners = owners.OrderByDescending(x => x.Age);
                    break;
                default:
                    owners = owners.OrderBy(x => x.Name);
                    break;
            }


            var count = owners.Count();
            IEnumerable<Owner> items = owners.Skip((page-1)*pageSize).Take(pageSize).ToList();


            OwnerViewModel ownerView = new OwnerViewModel
            {
                owners= items,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortOwnerViewModel(sortState),
                FilterViewModel = new FilterOwnerViewModel(name,surname,age)
            };

            return ownerView;
        }

        */


        public IEnumerable<Owner> GetAll()
        {
            return db.Owners;
        }

        public Owner Get(int id)
        {
            return db.Owners.Find(id);
        }

        public IEnumerable<Owner> find(Func<Owner, bool> predicate)
        {
            return db.Owners.Where(predicate).ToList();
        }

        public void Create(Owner item)
        {
            db.Owners.Add(item);
        }

        public void Update(Owner owner)
        {
            db.Entry(owner).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner != null)
            {
                db.Owners.Remove(owner);
            }
        }
    }
}
