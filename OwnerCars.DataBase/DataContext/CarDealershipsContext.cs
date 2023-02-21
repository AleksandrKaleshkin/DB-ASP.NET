using Microsoft.EntityFrameworkCore;
using OwnerCars.DataBase.Models;


namespace OwnerCars.Data
{
    public class CarDealershipsContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }

        public CarDealershipsContext(DbContextOptions options) : base(options)
        {

            
        }





    }
}
