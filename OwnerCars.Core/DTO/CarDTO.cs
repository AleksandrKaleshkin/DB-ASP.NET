
using OwnerCars.DataBase.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OwnerCars.Core.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }

        public string? NameImage { get; set; }

        public string? Path { get; set; }

        [Required(ErrorMessage = "Не указана марка")]
        [StringLength(100,MinimumLength = 2, ErrorMessage = "Длина строки может быть от 2 до 100 символов")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Не указана модель")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки может быть от 2 до 50 символов")]
        public string Model { get; set; }

        [Range(1890, 2025, ErrorMessage ="Недопустимы год выпууска")]
        public int Year { get; set; }

        [Range(5, 2000, ErrorMessage = "Недопустимая величина мощности")]
        public int Power { get; set; }

        public int OwnerId { get; set; }

        public Owner? Owner { get; set; }
    }
}
