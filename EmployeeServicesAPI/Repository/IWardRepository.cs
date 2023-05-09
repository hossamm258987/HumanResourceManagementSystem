using EmployeeServicesAPI.Models.DTOs;

namespace EmployeeServicesAPI.Repository
{
    public interface IWardRepository
    {
        Task<List<WardDTO>> GetWardList();
        Task<WardDTO> GetWardById(int id);
        Task<List<WardDTO>> GetWardByName(string name);
        Task<WardDTO> CreateUpdateWard(WardDTO wardDTO);
        Task<bool> DeleteWard(int wardId);
    }
}
