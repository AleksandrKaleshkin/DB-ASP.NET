using OwnerCars.Common.Models;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Models;
using OwnerCars.DataBase.Models;

namespace OwnerCars.Models
{
    public class CarViewModel
    {
        public IEnumerable<CarDTO>? Cars { get; set; }
        public PageViewModel? PageViewModel { get; set; }
        public FilterCarViewModel? FilterViewModel { get; set; }
        public SortCarViewModel? SortViewModel { get; set; }
    }
}
