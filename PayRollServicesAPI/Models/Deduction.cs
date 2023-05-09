using System.ComponentModel.DataAnnotations;

namespace PayRollServicesAPI.Models
{
    public class Deduction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmpId { get; set; }
        public Employee employee { get; set; }

        [Required]
        public DateTime Deduction_DT { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Name Must be Less Than 60 Charachtar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Description Must be Less Than 60 Charachtar")]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        public bool IsActive { get; set; }
    }
}
