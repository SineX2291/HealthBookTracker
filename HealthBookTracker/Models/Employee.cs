
using System.ComponentModel.DataAnnotations;

namespace HealthBookTracker.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Имя обязательно")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Фамилия обязательна")]
        public string LastName { get; set; } = string.Empty;
        public string? Position { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public DateTime? MedicalBookEndDate { get; set; }
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
