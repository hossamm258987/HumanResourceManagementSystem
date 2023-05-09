using PayRollServicesAPI.Models.DTOs;

namespace PayRollServicesAPI.Repository
{
    public interface IPayrollRepository
    {
        Task<List<PayrollDTO>> GetPayrollList(); //Done
        Task<PayrollDTO> GetPayrollById(int id); //Done
        Task<List<PayrollDTO>> GetPayrollByEmpId(int id); //Done
        Task<List<PayrollDTO>> GetTPayrollByEmpId(int id, DateTime startDate, DateTime endDate); //Done
        Task<List<PayrollDTO>> GetTPayroll(DateTime startDate, DateTime endDate); //Done
        Task<List<PayrollDTO>> GetMPayrollByEmpId(int id, int month); //Done
        Task<List<PayrollDTO>> GetMPayroll(int month); //Done
        Task<List<PayrollDTO>> GetPayrollByEmpName(string name); //Done
        Task<PayrollDTO> CreateUpdatePayroll(PayrollDTO payrollDTO); //Done
        Task<bool> DeletePayroll(int payrollId); //Done
    }
}
