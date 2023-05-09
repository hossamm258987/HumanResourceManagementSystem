using AutoMapper;
using PayRollServicesAPI.Models;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;

namespace PayRollServicesAPI.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public AttendanceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AttendanceDTO> CreateUpdateAttendance(AttendanceDTO attendanceDTO)
        {
            Attendance attendance = _mapper.Map<AttendanceDTO, Attendance>(attendanceDTO);
            Employee emp = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == attendance.EmpId);

            if(emp == null)
            {
                _db.Employees.Add(emp);
                await _db.SaveChangesAsync();
            }

            if (attendance.Id > 0)
            {
                _db.Attendances.Update(attendance);
            }
            else
            {
                _db.Attendances.Add(attendance);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Attendance, AttendanceDTO>(attendance);
        }

        public async Task<bool> DeleteAttendance(int attendanceId)
        {
            try
            {
                Attendance attendance = await _db.Attendances.FirstOrDefaultAsync(e =>
                    e.Id == attendanceId);
                if (attendance == null)
                {
                    return false;
                }
                _db.Attendances.Remove(attendance);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<AttendanceDTO>> GetAttendanceByEmpId(int id)
        {
            List<Attendance> attendance = await _db.Attendances.Where(e => e.EmpId == id)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<AttendanceDTO>>(attendance);
        }

        public async Task<List<AttendanceDTO>> GetAttendanceByEmpName(string name)
        {
            List<Attendance> attendance = await _db.Attendances.Where(e => e.employee.FName.Contains(name))
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<AttendanceDTO>>(attendance);
        }

        public async Task<AttendanceDTO> GetAttendanceById(int id)
        {
            Attendance attendance = await _db.Attendances.Where(e =>
                e.Id == id).Include(e => e.employee).IgnoreAutoIncludes().FirstOrDefaultAsync();
            return _mapper.Map<AttendanceDTO>(attendance);
        }

        public async Task<List<AttendanceDTO>> GetAttendanceList()
        {
            List<Attendance> attendance = await _db.Attendances.Include(e => e.employee)
                .IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<AttendanceDTO>>(attendance);
        }

        public async Task<List<AttendanceDTO>> GetMAttendanceByEmpId(int id, int month)
        {
            List<Attendance> attendance = await _db.Attendances.Where(e => e.EmpId == id 
                && e.Attendace_DT.Month == month).Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<AttendanceDTO>>(attendance);
        }

        public async Task<List<AttendanceDTO>> GetTAttendanceByEmpId(int id, DateTime startDate, DateTime endDate)
        {
            List<Attendance> attendance = await _db.Attendances.Where(e => e.EmpId == id
                && e.Attendace_DT.Date >= startDate.Date && e.Attendace_DT.Date <= endDate.Date)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<AttendanceDTO>>(attendance);
        }
    }
}
