using System.ComponentModel.DataAnnotations;

namespace Lr10.Models
{
    public class ConsultationRegistrationViewModel
    {
        [Required(ErrorMessage = "Введіть ім'я та прізвище")]
        [Display(Name = "Ім'я та прізвище")]
        [RegularExpression(@"^[A-Za-zА-Яа-яЇїІіЄєҐґ'-]{2,25}\s[A-Za-zА-Яа-яЇїІіЄєҐґ'-]{2,25}$", ErrorMessage = "Некоректне ім'я та прізвище")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Введіть Email")]
        [EmailAddress(ErrorMessage = "Некоректний Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Оберіть дату консультації")]
        [Display(Name = "Дата консультації")]
        [CustomDateValidation(ErrorMessage = "Оберіть коректну дату")]
        [CustomProductDateValidation(ErrorMessage = "Обраний продукт не може консультуватися в цей день тижня")]
        public DateTime ConsultationDate { get; set; }

        [Required(ErrorMessage = "Оберіть продукт")]
        [Display(Name = "Продукт")]
        public string Product { get; set; }
    }
}