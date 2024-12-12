using System.ComponentModel.DataAnnotations;

namespace Lr10.Models
{
    public class CustomProductDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime consultationDate)
            {
                var model = (ConsultationRegistrationViewModel)validationContext.ObjectInstance;
                var dayOfWeek = consultationDate.DayOfWeek;

                return dayOfWeek switch
                {
                    DayOfWeek.Monday when model.Product == "Основи" =>
                        new ValidationResult("Консультація 'Основи' не може бути в понеділок"),
                    DayOfWeek.Tuesday when model.Product == "Python" =>
                        new ValidationResult("Консультація 'Python' не може бути у вівторок"),
                    DayOfWeek.Wednesday when model.Product == "Java" =>
                        new ValidationResult("Консультація 'Java' не може бути в середу"),
                    DayOfWeek.Thursday when model.Product == "JavaScript" =>
                        new ValidationResult("Консультація 'JavaScript' не може бути в четвер"),
                    DayOfWeek.Friday when model.Product == "C++" =>
                        new ValidationResult("Консультація 'C++' не може бути в п'ятницю"),
                    _ => ValidationResult.Success
                };
            }
            return ValidationResult.Success;
        }
    }
}