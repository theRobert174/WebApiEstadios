using System.ComponentModel.DataAnnotations;

namespace WebApiEstadios.Validaciones
{
    public class firstCharCapital : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstChar = value.ToString()[0].ToString();

            if(firstChar != firstChar.ToUpper())
            {
                return new ValidationResult("Debe iniciar con mayuscula");
            }
            return ValidationResult.Success;
        }
    }
}
