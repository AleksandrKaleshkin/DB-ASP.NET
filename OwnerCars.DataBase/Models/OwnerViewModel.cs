using OwnerCars.Models;

namespace OwnerCars.DataBase.Models
{
    public class OwnerViewModel
    {
        public IEnumerable<Owner> owners { get; set; }
        public PageViewModel PageViewModel { get; set; }


    }

}
