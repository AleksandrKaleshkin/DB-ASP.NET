using OwnerCars.Data;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Models;

namespace OwnerCars.DataBase.Repositories
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private CarDealershipsContext db;
        private CarRepository carRepository;
        private OwnerRepository ownerRepository;

        public EFUnitOfWork(CarDealershipsContext db)
        {
            this.db = db;
        }


        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepository(db);
                }
                return carRepository;
            }
        }

        public IRepository<Owner> Owners
        {
            get
            {
                if (ownerRepository == null)
                {
                    ownerRepository = new OwnerRepository(db);
                }
                return ownerRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
