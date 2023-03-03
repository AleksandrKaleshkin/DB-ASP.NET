using Microsoft.EntityFrameworkCore.Metadata;
using Ninject.Modules;
using OwnerCars.Data;
using OwnerCars.DataBase.Interfaces;
using OwnerCars.DataBase.Repositories;

namespace OwnerCars.Core.Infrastructure
{
    internal class ServiceModule: NinjectModule
    {
        readonly CarDealershipsContext context;


        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(context);
        }
    }
}
