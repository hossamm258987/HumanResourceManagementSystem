namespace PayRollServicesAPI.Models.DTOs
{
    public class AttendanceDTO
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Employee employee { get; set; }
        public DateTime Attendace_DT { get; set; }
        public bool IsPresent { get; set; }
    }
}
