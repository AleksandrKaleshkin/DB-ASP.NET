using Microsoft.AspNetCore.Mvc.Rendering;
using OwnerCars.Models;

namespace OwnerCars.DataBase.Models
{
    public class CarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SelectList Owners { get; set; } = new SelectList (new List<Owner>(),"Id", "Name");
        public string? Brand { get; set; }
    }
}
