using OwnerCars.Common.Models;
using OwnerCars.Core.DTO;
using OwnerCars.Core.Models;

namespace OwnerCars.Models
{
    public class OwnerViewModel
    {
        
        public IEnumerable<OwnerDTO>? owners { get; set; }
        public PageViewModel? PageViewModel { get; set; }
        public FilterOwnerViewModel? FilterViewModel { get; set; }
        public SortOwnerViewModel? SortViewModel { get; set; }

        
    }

}
