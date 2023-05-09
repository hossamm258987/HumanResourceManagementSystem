namespace EmployeeServicesAPI.Models.DTOs
{
    public class EmployeePaginationDTO
    {
        public List<Employee> Employees { get; set; }
        public int Pages { get; set; }
        public int CurrentPages { get; set; }
    }
}
