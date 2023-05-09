using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeServicesAPI.Models
{
    public class Employee
    {
        //Personal Inforamtion
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "The First Name Must be Less Than 40 Charachtar")]
        public string FName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "The Middile Name Must be Less Than 40 Charachtar")]
        public string MName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "The Last Name Must be Less Than 40 Charachtar")]
        public string LName { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return (int)DateTime.Now.Year - (int)DoB.Year;
            }
        }

        [Required]
        [MaxLength(14, ErrorMessage = "The National Number Must Less Than 14")]
        public string NationalNumber { get; set; }

        [MaxLength(14, ErrorMessage = "The SNN Must Less Than 14")]
        public string SNN { get; set; }

        //Address Inforamtion
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [MaxLength(30)]
        public string Street { get; set; }

        [MaxLength(5)]
        public string PostalCode { get; set; }

        //Contact Information
        [Required]
        [MaxLength(13)]
        public string Phone { get; set; }

        [MaxLength(50, ErrorMessage = "Email Must be Less Than 50 Charachtar")]
        public string Email { get; set; }

        //Ward Information
        public int WardId { get; set; }
        public int JobTittleId { get; set; }
        public int SpecializationId { get; set; }
        public DateTime HireDate { get; set; }

        //Salary Inforamtion
        public double Salary { get; set; }
        public double Factor { get; set; }
        public double InsuranceTax { get; set; }

        //Education Inforamtion
        public string Certificates { get; set; }
        public byte YearsofExperience { get; set; }

        public bool IsActive { get; set; }

        public Ward Ward { get; set; }
        public JobTittle JobTittle { get; set; }
        public Specialization Specialization { get; set; }
    }
}
