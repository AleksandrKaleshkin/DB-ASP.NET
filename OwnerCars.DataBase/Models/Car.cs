using System.ComponentModel.DataAnnotations;


namespace OwnerCars.DataBase.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int Year { get; set; }

        public int Power { get; set; }

        public int OwnerId { get; set; }

        public virtual Owner? Owner { get; set; }

    }
}
