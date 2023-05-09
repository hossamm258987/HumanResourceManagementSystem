using EmployeeServicesAPI.Models.DTOs;

namespace EmployeeServicesAPI.Repository
{
    public interface ISpecializationRepository
    {
        Task<List<SpecializationDTO>> GetSpecializationList();
        Task<SpecializationDTO> GetSpecializationById(int id);
        Task<List<SpecializationDTO>> GetSpecializationByName(string name);
        Task<SpecializationDTO> CreateUpdateSpecialization(SpecializationDTO specializationDTO);
        Task<bool> DeleteSpecialization(int specializationId);
    }
}
