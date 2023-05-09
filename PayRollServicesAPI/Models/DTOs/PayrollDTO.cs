namespace PayRollServicesAPI.Models.DTOs
{
    public class PayrollDTO
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Employee employee { get; set; }
        public string Description { get; set; }
        public double IncentiveAmount { get; set; }
        public double NetSalary { get; set; }
        public double Tax { get; set; }
        public DateTime SalaryPayment_DT { get; set; }
        public int Month { get; set; }
    }
}
