using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthBookTracker.Domain.Validation
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public AgeValidationAttribute(int minAge)
        {
            _minAge = minAge;
            ErrorMessage = $"Сотрудник должен быть старше {_minAge} лет.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
                var today = DateTime.Today;
                var age = today.Year - dateOfBirth.Year;
                if (dateOfBirth.Date > today.AddYears(-age)) age--;

                if (age < _minAge)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
