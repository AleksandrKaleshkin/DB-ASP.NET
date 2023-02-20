using OwnerCars.Models;

namespace OwnerCars.DataBase.Models
{
    public class OwnerViewModel
    {
        public IEnumerable<Owner> owners { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public int? Age { get; set; }


    }

}
