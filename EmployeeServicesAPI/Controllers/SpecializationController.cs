using Microsoft.AspNetCore.Mvc;
using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Repository;

namespace EmployeeServicesAPI.Controllers
{
    [Route("api/specialization")]
    public class SpecializationController : ControllerBase
    {
        protected ResponseDTO _response;
        private ISpecializationRepository _specializationRepository;

        public SpecializationController(ISpecializationRepository specializationRepository)
        {
            _specializationRepository = specializationRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<SpecializationDTO> specializationDTOs = await _specializationRepository.GetSpecializationList();
                _response.Result = specializationDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                SpecializationDTO specializationDTO = await _specializationRepository.GetSpecializationById(id);
                _response.Result = specializationDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("specialname/{name}")]
        public async Task<object> GetbyName(string name)
        {
            try
            {
                IEnumerable<SpecializationDTO> specializationDTO = await _specializationRepository.GetSpecializationByName(name);
                _response.Result = specializationDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] SpecializationDTO specializationDTO)
        {
            try
            {
                SpecializationDTO model = await _specializationRepository.CreateUpdateSpecialization(specializationDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
        public async Task<object> Put([FromBody] SpecializationDTO specializationDTO)
        {
            try
            {
                SpecializationDTO model = await _specializationRepository.CreateUpdateSpecialization(specializationDTO);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _specializationRepository.DeleteSpecialization(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
