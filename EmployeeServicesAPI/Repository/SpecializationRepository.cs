using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Data;
using AutoMapper;
using EmployeeServicesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServicesAPI.Repository
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public SpecializationRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<SpecializationDTO> CreateUpdateSpecialization(SpecializationDTO specializationDTO)
        {
            Specialization specialization = _mapper.Map<SpecializationDTO, Specialization>(specializationDTO);
            if (specialization.SpecializationId > 0)
            {
                _db.Specializations.Update(specialization);
            }
            else
            {
                _db.Specializations.Add(specialization);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Specialization, SpecializationDTO>(specialization);
        }

        public async Task<bool> DeleteSpecialization(int specializationId)
        {
            try
            {
                Specialization specialization = await _db.Specializations.FirstOrDefaultAsync(s =>
                    s.SpecializationId == specializationId);
                if (specialization == null)
                {
                    return false;
                }
                _db.Specializations.Remove(specialization);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<SpecializationDTO> GetSpecializationById(int id)
        {
            Specialization specialization = await _db.Specializations.FirstOrDefaultAsync(s =>
                s.SpecializationId == id);
            return _mapper.Map<SpecializationDTO>(specialization);
        }

        public async Task<List<SpecializationDTO>> GetSpecializationByName(string name)
        {
            List<Specialization> specialization = await _db.Specializations.Where(s =>
                s.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<SpecializationDTO>>(specialization);
        }

        public async Task<List<SpecializationDTO>> GetSpecializationList()
        {
            List<Specialization> specialization = await _db.Specializations.ToListAsync();
            return _mapper.Map<List<SpecializationDTO>>(specialization);
        }
    }
}
