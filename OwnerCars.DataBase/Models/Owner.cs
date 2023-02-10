using OwnerCars.DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace OwnerCars.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string?  SurName { get; set; } 

        public int Age { get; set; }

        public string? Email { get; set; } 

        public virtual ICollection<Car>? Cars { get; set; } 

    }
}
