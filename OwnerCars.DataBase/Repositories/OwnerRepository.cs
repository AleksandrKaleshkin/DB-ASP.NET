
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OwnerCars.Data;
using OwnerCars.DataBase.Models;
using OwnerCars.Models;
using System.Security.Cryptography.X509Certificates;

namespace OwnerCars.DataBase.Repositories
{
    public class OwnerRepository
    {
        private CarDealershipsContext db;
        static SortStateOwner sortowner;

        public OwnerRepository(CarDealershipsContext db)
        {
            this.db = db;
        }



        public SortStateOwner Sort(string state)
        {
            switch (state)
            {
                case "NameSort":
                     sortowner = sortowner == SortStateOwner.NameAsc ? SortStateOwner.NameDesc : SortStateOwner.NameAsc;
                break;
                case "SurNameSort":
                    sortowner = sortowner == SortStateOwner.SurNameAsc ? SortStateOwner.SurNameDesc : SortStateOwner.SurNameAsc;
                break;

                case "AgeSort":
                    sortowner = sortowner == SortStateOwner.AgeAsc ? SortStateOwner.AgeDesc : SortStateOwner.AgeAsc;
                    break;
                default:
                    sortowner = SortStateOwner.NameAsc;
                break;
            }
            return sortowner;
        }
    

    public OwnerViewModel GetOwnerList(int page =1)
        {
            int pageSize = 4;
            IEnumerable<Owner> owners = db.Owners;
            owners = sortowner switch
            {
                SortStateOwner.NameDesc => owners.OrderByDescending(x => x.Name),
                SortStateOwner.AgeAsc => owners.OrderBy(x => x.Age),
                SortStateOwner.AgeDesc => owners.OrderByDescending(x => x.Age),
                SortStateOwner.SurNameAsc => owners.OrderBy(x => x.SurName),
                SortStateOwner.SurNameDesc => owners.OrderByDescending(x => x.SurName),
                _ => owners.OrderBy(x => x.Name)
            };
            var count = owners.Count();
            IEnumerable<Owner> items = owners.Skip((page-1)*pageSize).Take(pageSize).ToList();

            PageViewModel pageView = new PageViewModel(count, page, pageSize);



            OwnerViewModel ownerView = new OwnerViewModel
            {
                PageViewModel = pageView,
                owners = items
            };

            return ownerView;
        }

        public Owner GetOwner(int id)
        {
            return db.Owners.Find(id);
        }

        public void Add(Owner owner)
        {
 
            db.Owners.Add(owner);
            db.SaveChanges();
        }

        public void Remove(int id) 
        {
            Owner owner = db.Owners.Find(id);
            if (owner != null)
            {
            db.Owners.Remove(owner);
            db.SaveChanges();   
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Owner owner)
        {
            db.Entry(owner).State = EntityState.Modified;
            db.SaveChanges();
        }


    }
}
