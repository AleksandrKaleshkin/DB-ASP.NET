using Microsoft.AspNetCore.Mvc.Rendering;

namespace OwnerCars.DataBase.Models
{
    public class FilterCarViewModel
    {
        public FilterCarViewModel(List<Owner> owners, string brand,int? owner)
        {
            owners.Insert(0, new Owner { Name = "Все", Id = 0 });
            Owners = new SelectList(owners, "Id", "Name", owner);
            SelectedBrand= brand;
            SelectedOwner= owner;

        }
        public SelectList Owners { get; private set; }
        public int? SelectedOwner { get; private set; }
        public string SelectedBrand { get; private set; }
    }
}
