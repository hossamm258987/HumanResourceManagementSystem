using System.ComponentModel.DataAnnotations;

namespace EmployeeServicesAPI.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "Department Name Must be Less Than 80 Charachtar")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Department Description Must be Less Than 250 Charachtar")]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        //public IEnumerable<Employee> Employees { get; set; }
    }
}
