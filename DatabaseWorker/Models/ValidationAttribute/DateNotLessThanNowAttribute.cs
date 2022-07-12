using System.ComponentModel.DataAnnotations;

namespace DatabaseWorker.Models.ValidationAttribute
{
    public class DateNotLessThanNowAttribute: System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            ErrorMessage = "The date must not be less than the current date!";

            if (value is DateTime date)
            {
                if (date < DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success!;
        }
    }
}
