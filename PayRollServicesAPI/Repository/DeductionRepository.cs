using AutoMapper;
using PayRollServicesAPI.Models;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace PayRollServicesAPI.Repository
{
    public class DeductionRepository : IDeductionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public DeductionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DeductionDTO> CreateUpdateDeduction(DeductionDTO deductionDTO)
        {
            Deduction deduction = _mapper.Map<DeductionDTO, Deduction>(deductionDTO);
            Employee emp = await _db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == deduction.EmpId);

            if (emp == null)
            {
                _db.Employees.Add(emp);
                await _db.SaveChangesAsync();
            }

            if (deduction.Id > 0)
            {
                _db.Deductions.Update(deduction);
            }
            else
            {
                _db.Deductions.Add(deduction);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Deduction, DeductionDTO>(deduction);
        }

        public async Task<bool> DeleteDeduction(int deductionId)
        {
            try
            {
                Deduction deduction = await _db.Deductions.FirstOrDefaultAsync(e =>
                    e.Id == deductionId);
                if (deduction == null)
                {
                    return false;
                }
                _db.Deductions.Remove(deduction);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<DeductionDTO>> GetADeductionByEmpId(int id)
        {
            List<Deduction> deduction = await _db.Deductions.Where(e => e.EmpId == id  && e.IsActive == true)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DeductionDTO>>(deduction);
        }

        public async Task<List<DeductionDTO>> GetDeductionByEmpId(int id)
        {
            List<Deduction> deduction = await _db.Deductions.Where(e => e.EmpId == id)
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DeductionDTO>>(deduction);
        }

        public async Task<List<DeductionDTO>> GetDeductionByEmpName(string name)
        {
            List<Deduction> deduction = await _db.Deductions.Where(e => e.employee.FName.Contains(name))
                .Include(e => e.employee).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DeductionDTO>>(deduction);
        }

        public async Task<DeductionDTO> GetDeductionById(int id)
        {
            Deduction deduction = await _db.Deductions.Where(e =>
                e.Id == id).Include(e => e.employee).IgnoreAutoIncludes().FirstOrDefaultAsync();
            return _mapper.Map<DeductionDTO>(deduction);
        }

        public async Task<List<DeductionDTO>> GetDeductionList()
        {
            List<Deduction> deduction = await _db.Deductions.Include(e => e.employee)
                .IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<DeductionDTO>>(deduction);
        }
    }
}
