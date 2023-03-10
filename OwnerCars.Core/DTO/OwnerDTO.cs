using System.ComponentModel.DataAnnotations;

namespace OwnerCars.Core.DTO
{
    public class OwnerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string SurName { get; set; }

        [Range (18, 110, ErrorMessage ="Недопустимый возраст" )]
        public int Age { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
    }
}
