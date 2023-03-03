using OwnerCars.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnerCars.DataBase.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Car> Cars { get; }
        IRepository<Owner> Owners { get; }
        void Save();
    }
}
