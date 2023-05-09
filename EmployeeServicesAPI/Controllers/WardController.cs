using Microsoft.AspNetCore.Mvc;
using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Repository;

namespace EmployeeServicesAPI.Controllers
{
    [Route("api/ward")]
    public class WardController : ControllerBase
    {
        protected ResponseDTO _response;
        private IWardRepository _wardRepository;

        public WardController(IWardRepository wardRepository)
        {
            _wardRepository = wardRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<WardDTO> wardDTOs = await _wardRepository.GetWardList();
                _response.Result = wardDTOs;
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
                WardDTO wardDTO = await _wardRepository.GetWardById(id);
                _response.Result = wardDTO;
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
        [Route("wardname/{name}")]
        public async Task<object> GetbyName(string name)
        {
            try
            {
                IEnumerable<WardDTO> wardDTO = await _wardRepository.GetWardByName(name);
                _response.Result = wardDTO;
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
        public async Task<object> Post([FromBody] WardDTO wardDTO)
        {
            try
            {
                WardDTO model = await _wardRepository.CreateUpdateWard(wardDTO);
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
        public async Task<object> Put([FromBody] WardDTO wardDTO)
        {
            try
            {
                WardDTO model = await _wardRepository.CreateUpdateWard(wardDTO);
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
                bool isSuccess = await _wardRepository.DeleteWard(id);
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
