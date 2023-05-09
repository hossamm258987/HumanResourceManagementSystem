using EmployeeServicesAPI.Models.DTOs;

namespace EmployeeServicesAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDTO>> GetEmployeeList(); //Done
        Task<EmployeeDTO> GetEmployeeById(int id); //Done 
        Task<List<EmployeeDTO>> GetEmployeeByName(string fName, string mName, string lName); //Done
        Task<List<EmployeeDTO>> GetEmployeeByNN(string nn); //Done
        Task<List<EmployeeDTO>> GetEmployeeBySNN(string snn); //Done
        Task<List<EmployeeDTO>> OrderEmployee(string order); //Done
        Task<List<EmployeeDTO>> SearchEmployee(string search); //Done
        Task<EmployeePaginationDTO> PaginationEmployeeList(int page, int size = 10);
        Task<List<EmployeeDTO>> GetEmployeeByWard(int wardId); //Done
        Task<List<EmployeeDTO>> GetEmployeeByJobTittle(int jobTittleId); //Done
        Task<List<EmployeeDTO>> GetEmployeeBySpecialization(int specializationId); //Done
        Task<EmployeeDTO> CreateUpdateEmployee(EmployeeDTO employeeDTO); //Done
        Task<bool> DeleteEmployee(int employeeId); //Done
    }
}
