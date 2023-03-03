using Microsoft.AspNetCore.Mvc.Rendering;
using OwnerCars.Core.DTO;

namespace OwnerCars.Core.Models
{
    public class FilterCarViewModel
    {
        public FilterCarViewModel(List<OwnerDTO> owners, string? brand,int? owner)
        {
            
            owners.Insert(0, new OwnerDTO { Name = "Все", Id = 0 });
            Owners = new SelectList(owners, "Id", "Name", owner);
            SelectedOwner= owner;
            SelectedBrand= brand;

        }
        public SelectList Owners { get; private set; }
        public int? SelectedOwner { get; private set; }
        public string? SelectedBrand { get; private set; }
    }
}
