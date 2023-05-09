using PayRollServicesAPI.Models.DTOs;

namespace PayRollServicesAPI.Repository
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceDTO>> GetAttendanceList();
        Task<AttendanceDTO> GetAttendanceById(int id);
        Task<List<AttendanceDTO>> GetAttendanceByEmpId(int id);
        Task<List<AttendanceDTO>> GetTAttendanceByEmpId(int id, DateTime startDate, DateTime endDate);
        Task<List<AttendanceDTO>> GetMAttendanceByEmpId(int id, int month);
        Task<List<AttendanceDTO>> GetAttendanceByEmpName(string name);
        Task<AttendanceDTO> CreateUpdateAttendance(AttendanceDTO attendanceDTO);
        Task<bool> DeleteAttendance(int attendanceId);
    }
}
