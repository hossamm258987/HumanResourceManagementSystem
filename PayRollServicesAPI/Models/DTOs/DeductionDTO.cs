namespace PayRollServicesAPI.Models.DTOs
{
    public class DeductionDTO
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Employee employee { get; set; }
        public DateTime Deduction_DT { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
