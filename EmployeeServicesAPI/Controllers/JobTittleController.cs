using Microsoft.AspNetCore.Mvc;
using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Repository;

namespace EmployeeServicesAPI.Controllers
{
    [Route("api/jobtittle")]
    public class JobTittleController : ControllerBase
    {
        protected ResponseDTO _response;
        private IJobTittleRepository _jobTittleRepository;

        public JobTittleController(IJobTittleRepository jobTittleRepository)
        {
            _jobTittleRepository = jobTittleRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<JobTittleDTO> jobTittleDTOs = await _jobTittleRepository.GetJobTittleList();
                _response.Result = jobTittleDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                JobTittleDTO jobTittleDTO = await _jobTittleRepository.GetJobTittleById(id);
                _response.Result = jobTittleDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done

        [HttpGet]
        [Route("tittle/{name}")]
        public async Task<object> GetbyName(string name)
        {
            try
            {
                IEnumerable<JobTittleDTO> jobTittleDTO = await _jobTittleRepository.GetJobTittleByName(name);
                _response.Result = jobTittleDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done


        [HttpPost]
        public async Task<object> Post([FromBody] JobTittleDTO jobTittleDTO)
        {
            try
            {
                JobTittleDTO model = await _jobTittleRepository.CreateUpdateJobTittle(jobTittleDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done


        [HttpPut]
        public async Task<object> Put([FromBody] JobTittleDTO jobTittleDTO)
        {
            try
            {
                JobTittleDTO model = await _jobTittleRepository.CreateUpdateJobTittle(jobTittleDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _jobTittleRepository.DeleteJobTittle(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done
    }
}
