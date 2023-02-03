using Microsoft.EntityFrameworkCore;
using OwnerCars.Models;

namespace OwnerCars.Data
{
    public class CarDealershipsContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }

        public CarDealershipsContext (DbContextOptions options): base(options){
        Database.EnsureCreated();
        }



    }
}
