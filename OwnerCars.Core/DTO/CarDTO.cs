﻿
using OwnerCars.DataBase.Models;

namespace OwnerCars.Core.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public string? Model { get; set; }

        public int Year { get; set; }

        public int Power { get; set; }

        public int OwnerId { get; set; }

        public Owner? Owner { get; set; }
    }
}
