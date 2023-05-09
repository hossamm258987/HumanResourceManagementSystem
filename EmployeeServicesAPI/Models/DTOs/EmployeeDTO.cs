namespace EmployeeServicesAPI.Models.DTOs
{
    public class EmployeeDTO
    {
        //Personal Inforamtion
        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public bool Gender { get; set; }
        public DateTime DoB { get; set; }
        public int Age
        {
            get
            {
                return (int)DateTime.Now.Year - (int)DoB.Year;
            }
        }
        public string NationalNumber { get; set; }
        public string SNN { get; set; }

        //Address Inforamtion
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        //Contact Information
        public string Phone { get; set; }
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

        public virtual Ward Ward { get; set; }
        public virtual JobTittle JobTittle { get; set; }
        public virtual Specialization Specialization { get; set; }
    }
}
