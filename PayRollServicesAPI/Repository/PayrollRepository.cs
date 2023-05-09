using AutoMapper;
using PayRollServicesAPI.Models;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace PayRollServicesAPI.Repository
{
    public class PayrollRepository : IPayrollRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PayrollRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PayrollDTO> CreateUpdatePayroll(PayrollDTO payrollDTO)
        {
            Payroll payroll = _mapper.Map<PayrollDTO, Payroll>(payrollDTO);

            List<Attendance> daysByMonth = await _db.Attendances.Where(e => e.EmpId == payroll.EmpId
                && e.Attendace_DT.Month == payroll.Month).ToListAsync();

            List<Deduction> activeDeductions = await _db.Deductions.Where(e => e.EmpId == payroll.EmpId
                && e.IsActive == true).ToListAsync();

            Employee emp = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == payroll.EmpId);

            if (emp == null)
            {
                _db.Employees.Add(emp);
                await _db.SaveChangesAsync();
            }

            double dect = 0.0;

            foreach(Deduction d in activeDeductions)
            {
                dect += d.Amount;
            }

            payroll.NetSalary = (payroll.employee.Salary/daysByMonth.Count) + (payroll.IncentiveAmount * payroll.employee.Salary) - (payroll.Tax * payroll.employee.Salary) - (payroll.employee.Factor * payroll.employee.Salary) - dect;
            
            if (payroll.Id > 0)
            {
                _db.Payrolls.Update(payroll);
            }
            else
            {
                _db.Payrolls.Add(payroll);

                foreach (Deduction d in activeDeductions)
                {
                    d.IsActive = false;
                    _db.Deductions.Update(d);
                }
            }           

            await _db.SaveChangesAsync();

            return _mapper.Map<Payroll, PayrollDTO>(payroll);
        }

        public async Task<bool> DeletePayroll(int payrollId)
        {
            try
            {
                Payroll payroll = await _db.Payrolls.FirstOrDefaultAsync(p => p.Id == payrollId);
                if (payroll == null)
                {
                    return false;
                }
                _db.Payrolls.Remove(payroll);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<PayrollDTO>> GetMPayroll(int month)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(p => p.Month == month)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<List<PayrollDTO>> GetMPayrollByEmpId(int id, int month)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(p => p.Month == month && p.EmpId == id)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<List<PayrollDTO>> GetPayrollByEmpId(int id)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(p => p.EmpId == id)
               .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<List<PayrollDTO>> GetPayrollByEmpName(string name)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(e => e.employee.FName.Contains(name))
               .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<PayrollDTO> GetPayrollById(int id)
        {
            Payroll payroll = await _db.Payrolls.Include(e => e.employee).IgnoreAutoIncludes()
                .FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<PayrollDTO>(payroll);
        }

        public async Task<List<PayrollDTO>> GetPayrollList()
        {
            List<Payroll> payroll = await _db.Payrolls.Include(e => e.employee)
                .IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<List<PayrollDTO>> GetTPayroll(DateTime startDate, DateTime endDate)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(p => p.SalaryPayment_DT.Date >= startDate 
                && p.SalaryPayment_DT.Date <= endDate)
               .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }

        public async Task<List<PayrollDTO>> GetTPayrollByEmpId(int id, DateTime startDate, DateTime endDate)
        {
            List<Payroll> payroll = await _db.Payrolls.Where(p => p.EmpId == id 
                && p.SalaryPayment_DT.Date >= startDate
                && p.SalaryPayment_DT.Date <= endDate)
               .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<PayrollDTO>>(payroll);
        }
    }
}
