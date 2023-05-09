using System.ComponentModel.DataAnnotations;

namespace PayRollServicesAPI.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpId { get; set; }

        public Employee employee { get ; set; }

        [Required]
        public DateTime Attendace_DT { get; set; }

        [Required]
        public bool IsPresent { get; set; }
    }
}
