using PayRollServicesAPI.Models.DTOs;

namespace PayRollServicesAPI.Repository
{
    public interface IDeductionRepository
    {
        Task<List<DeductionDTO>> GetDeductionList();
        Task<DeductionDTO> GetDeductionById(int id);
        Task<List<DeductionDTO>> GetDeductionByEmpId(int id);
        Task<List<DeductionDTO>> GetADeductionByEmpId(int id);
        Task<List<DeductionDTO>> GetDeductionByEmpName(string name);
        Task<DeductionDTO> CreateUpdateDeduction(DeductionDTO deductionDTO);
        Task<bool> DeleteDeduction(int deductionId);
    }
}
