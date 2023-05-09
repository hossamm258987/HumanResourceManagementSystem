using Microsoft.AspNetCore.Mvc;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Repository;

namespace PayRollServicesAPI.Controllers
{
    [Route("api/deduction")]
    public class DeductionController : ControllerBase
    {
        protected ResponseDTO _response;
        private IDeductionRepository _deductionRepository;

        public DeductionController(IDeductionRepository deductionRepository)
        {
            _deductionRepository = deductionRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DeductionDTO> deductionDTOs = await _deductionRepository.GetDeductionList();
                _response.Result = deductionDTOs;
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
                DeductionDTO deductionDTO = await _deductionRepository.GetDeductionById(id);
                _response.Result = deductionDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }  //Done

        [HttpGet]
        [Route("empid/{eid}")]
        public async Task<object> GetByEId(int eid)
        {
            try
            {
                List<DeductionDTO> deductionDTO = await _deductionRepository.GetDeductionByEmpId(eid);
                _response.Result = deductionDTO;
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
        [Route("ename/{name}")]
        public async Task<object> GetByEName(string name)
        {
            try
            {
                List<DeductionDTO> deductionDTO = await _deductionRepository.GetDeductionByEmpName(name);
                _response.Result = deductionDTO;
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
        [Route("aempid/{eid}")]
        public async Task<object> GetByAEId(int eid)
        {
            try
            {
                List<DeductionDTO> deductionDTO = await _deductionRepository.GetADeductionByEmpId(eid);
                _response.Result = deductionDTO;
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
        public async Task<object> Post([FromBody] DeductionDTO deductionDTO)
        {
            try
            {
                DeductionDTO model = await _deductionRepository.CreateUpdateDeduction(deductionDTO);
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
        public async Task<object> Put([FromBody] DeductionDTO deductionDTO)
        {
            try
            {
                DeductionDTO model = await _deductionRepository.CreateUpdateDeduction(deductionDTO);
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
                bool isSuccess = await _deductionRepository.DeleteDeduction(id);
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
