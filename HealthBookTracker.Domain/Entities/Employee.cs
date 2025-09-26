using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
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
