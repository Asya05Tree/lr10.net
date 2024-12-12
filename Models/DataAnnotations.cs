using System.ComponentModel.DataAnnotations;

namespace Lr10.Models
{
    public class CustomDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                if (date <= DateTime.Now)
                    return false;
                if (date > DateTime.Today.AddMonths(6)) //планувати треба не на 10 років вперед
                    return false;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    return false;
                // вночі робити консультації неправильно
                if (date.TimeOfDay < new TimeSpan(8, 0, 0) || date.TimeOfDay > new TimeSpan(19, 0, 0))
                    return false;

                return true;
            }
            return false;
        }

    }
}
