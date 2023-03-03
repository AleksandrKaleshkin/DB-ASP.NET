using Ninject.Modules;
using OwnerCars.Core.Interfaces;
using OwnerCars.Core.Services;

namespace OwnerCars.Api.Util
{
    public class OwnerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarService>();
        }
    }
}
