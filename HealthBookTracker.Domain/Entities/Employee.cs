using System.ComponentModel.DataAnnotations;
using HealthBookTracker.Domain.Validation;


namespace HealthBookTracker.Domain.Entities
{
 
    public class Employee
    {
   
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно")] 
        [StringLength(20)]      
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Фамилия обязательна")] 
        [StringLength(20)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Position { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [AgeValidation(18, ErrorMessage = "Сотрудник должен быть старше 18 лет.")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        public DateTime? MedicalBookEndDate { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int? DaysUntilExpiration
        {
            get
            {
                if (MedicalBookEndDate == null) return null;
                return (MedicalBookEndDate.Value - DateTime.Today).Days;
            }
        }
    }
}
