using EmployeeServicesAPI.Models.DTOs;
using AutoMapper;
using EmployeeServicesAPI.Data;
using EmployeeServicesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServicesAPI.Repository
{
    public class WardRepository : IWardRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public WardRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<WardDTO> CreateUpdateWard(WardDTO wardDTO)
        {
            Ward ward = _mapper.Map<WardDTO, Ward>(wardDTO);
            if (ward.WardId > 0)
            {
                _db.Wards.Update(ward);
            }
            else
            {
                _db.Wards.Add(ward);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Ward, WardDTO>(ward);
        }

        public async Task<bool> DeleteWard(int wardId)
        {
            try
            {
                Ward ward = await _db.Wards.FirstOrDefaultAsync(w => w.WardId == wardId);
                if (ward == null)
                {
                    return false;
                }
                _db.Wards.Remove(ward);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<WardDTO> GetWardById(int id)
        {
            Ward ward = await _db.Wards.Where(w => w.WardId == id).FirstOrDefaultAsync();
            return _mapper.Map<WardDTO>(ward);
        }

        public async Task<List<WardDTO>> GetWardByName(string name)
        {
            var wardList = await _db.Wards.Where(w => w.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<WardDTO>>(wardList);
        }

        public async Task<List<WardDTO>> GetWardList()
        {
            List<Ward> wardList = await _db.Wards.ToListAsync();
            return _mapper.Map<List<WardDTO>>(wardList);
        }
    }
}
