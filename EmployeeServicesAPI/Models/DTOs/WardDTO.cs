namespace EmployeeServicesAPI.Models.DTOs
{
    public class WardDTO
    {
        public int WardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ManagerId { get; set; }
        public bool IsActive { get; set; }
    }
}
