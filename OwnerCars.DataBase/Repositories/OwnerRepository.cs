
using Microsoft.EntityFrameworkCore;
using OwnerCars.Data;
using OwnerCars.Models;


namespace OwnerCars.DataBase.Repositories
{
    public class OwnerRepository
    {
        private CarDealershipsContext db;

        public OwnerRepository(CarDealershipsContext db)
        {
            this.db = db;
        }

        public IEnumerable<Owner> GetOwnerList()
        {
            return db.Owners.ToList();
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
