using AutoMapper;
using EmployeeServicesAPI.Data;
using EmployeeServicesAPI.Models;
using EmployeeServicesAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServicesAPI.Repository
{
    public class JobTittleRepository : IJobTittleRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public JobTittleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<JobTittleDTO> CreateUpdateJobTittle(JobTittleDTO jobTittleDTO)
        {
            JobTittle jobTittle = _mapper.Map<JobTittleDTO, JobTittle>(jobTittleDTO);
            if (jobTittle.JobTittleId > 0)
            {
                _db.JobTittles.Update(jobTittle);
            }
            else
            {
                _db.JobTittles.Add(jobTittle);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<JobTittle, JobTittleDTO>(jobTittle);
        }

        public async Task<bool> DeleteJobTittle(int jobTittleId)
        {
            try
            {
                JobTittle jobTittle = await _db.JobTittles.FirstOrDefaultAsync(j =>
                    j.JobTittleId == jobTittleId);
                if (jobTittle == null)
                {
                    return false; ;
                }
                _db.JobTittles.Remove(jobTittle);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<JobTittleDTO> GetJobTittleById(int id)
        {
            JobTittle jobTittle = await _db.JobTittles.Where(j =>
                j.JobTittleId == id).FirstOrDefaultAsync();
            return _mapper.Map<JobTittleDTO>(jobTittle);
        }

        public async Task<List<JobTittleDTO>> GetJobTittleByName(string name)
        {
            List<JobTittle> jobTittle = await _db.JobTittles.Where(j =>
                j.Name.Contains(name)).ToListAsync();
            return _mapper.Map<List<JobTittleDTO>>(jobTittle);
        }

        public async Task<List<JobTittleDTO>> GetJobTittleList()
        {
            List<JobTittle> jobTittle = await _db.JobTittles.ToListAsync();
            return _mapper.Map<List<JobTittleDTO>>(jobTittle);
        }
    }
}
