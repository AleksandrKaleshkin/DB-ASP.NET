using Microsoft.AspNetCore.Mvc.Rendering;

namespace OwnerCars.DataBase.Models
{
    public class CarViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterCarViewModel FilterViewModel { get; set; }
        public SortCarViewModel SortViewModel { get; set; }
    }
}
