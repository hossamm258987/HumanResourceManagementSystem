using AutoMapper;
using EmployeeServicesAPI.Data;
using EmployeeServicesAPI.Models;
using EmployeeServicesAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServicesAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> CreateUpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<EmployeeDTO, Employee>(employeeDTO);
            if (employee.EmployeeId > 0)
            {
                _db.Employees.Update(employee);
            }
            else
            {
                _db.Employees.Add(employee);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task<bool> DeleteEmployee(int employeeId)
        {
            try
            {
                Employee employee = await _db.Employees.FirstOrDefaultAsync(e =>
                    e.EmployeeId == employeeId);
                if (employee == null)
                {
                    return false;
                }
                _db.Employees.Remove(employee);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            Employee employee = await _db.Employees.Where(e =>
                e.EmployeeId == id).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().FirstOrDefaultAsync();
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeByJobTittle(int jobTittleId)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.JobTittleId == jobTittleId).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeByName(string fName, string mName, string lName)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.FName.Contains(fName) || e.MName.Contains(mName)
                || e.LName.Contains(lName)).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeByNN(string nn)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.NationalNumber.Contains(nn)).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeBySNN(string snn)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.SNN.Contains(snn)).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeBySpecialization(int specializationId)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.SpecializationId == specializationId).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeByWard(int wardId)
        {
            List<Employee> employee = await _db.Employees.Where(e =>
                e.WardId == wardId).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> GetEmployeeList()
        {
            List<Employee> employee = await _db.Employees.Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }

        public async Task<List<EmployeeDTO>> OrderEmployee(string order)
        {
            List<Employee> employee = await _db.Employees.Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();

            switch (order)
            {
                case "FName_asc":
                    employee.OrderBy(employee => employee.FName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "FName_desc":
                    employee.OrderByDescending(employee => employee.FName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "MName_asc":
                    employee.OrderBy(employee => employee.MName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "MName_desc":
                    employee.OrderByDescending(employee => employee.MName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "LName_asc":
                    employee.OrderBy(employee => employee.LName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "LName_desc":
                    employee.OrderByDescending(employee => employee.LName).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Age_asc":
                    employee.OrderBy(employee => employee.Age).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Age_desc":
                    employee.OrderByDescending(employee => employee.Age).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Salary_asc":
                    employee.OrderBy(employee => employee.Salary).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Salary_desc":
                    employee.OrderByDescending(employee => employee.Salary).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Ward_asc":
                    employee.OrderBy(employee => employee.WardId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Ward_desc":
                    employee.OrderByDescending(employee => employee.WardId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Tittle_asc":
                    employee.OrderBy(employee => employee.JobTittleId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Tittle_desc":
                    employee.OrderByDescending(employee => employee.JobTittleId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Special_asc":
                    employee.OrderBy(employee => employee.SpecializationId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Special_desc":
                    employee.OrderByDescending(employee => employee.SpecializationId).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "HireD_asc":
                    employee.OrderBy(employee => employee.HireDate).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "HireD_desc":
                    employee.OrderByDescending(employee => employee.HireDate).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Active_asc":
                    employee.OrderBy(employee => employee.IsActive).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                case "Active_desc":
                    employee.OrderByDescending(employee => employee.IsActive).ToList();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
                default:
                    employee = await _db.Employees.ToListAsync();
                    return _mapper.Map<List<EmployeeDTO>>(employee);
            }
        }

        //Not Work Yet.......!
        public async Task<EmployeePaginationDTO> PaginationEmployeeList(int page, int size = 10)
        {
            var pageResult = (float)size;
            var pageCount = Math.Ceiling(_db.Employees.Count() / pageResult);

            var employees = await _db.Employees
                .Skip(page - 1 * size)
                .Take((int)pageResult).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();

            var pagination = new EmployeePaginationDTO
            {
                Employees = employees,
                CurrentPages = page,
                Pages = (int)pageCount
            };
            return pagination;
        }

        public async Task<List<EmployeeDTO>> SearchEmployee(string search)
        {
            List<Employee> employee = new List<Employee>();
            if (!string.IsNullOrEmpty(search))
            {
                employee = await _db.Employees.Where(e =>
                    e.FName.Contains(search) ||
                    e.MName.Contains(search) ||
                    e.LName.Contains(search) ||
                    e.NationalNumber.Contains(search) ||
                    e.SNN.Contains(search) ||
                    e.Certificates.Contains(search) ||
                    e.Ward.Name.Contains(search) ||
                    e.JobTittle.Name.Contains(search) ||
                    e.Specialization.Name.Contains(search)).Include(w => w.Ward)
                .Include(j => j.JobTittle).Include(s => s.Specialization).IgnoreAutoIncludes().ToListAsync();
            }
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }
    }
}
