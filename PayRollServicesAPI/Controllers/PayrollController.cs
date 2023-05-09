using Microsoft.AspNetCore.Mvc;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Repository;

namespace PayRollServicesAPI.Controllers
{
    [Route("api/payroll")]
    public class PayrollController : ControllerBase
    {
        protected ResponseDTO _response;
        private IPayrollRepository _payrollRepository;

        public PayrollController(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<PayrollDTO> payrollDTOs = await _payrollRepository.GetPayrollList();
                _response.Result = payrollDTOs;
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
                PayrollDTO payrollDTO = await _payrollRepository.GetPayrollById(id);
                _response.Result = payrollDTO;
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
        [Route("time/{eid}/{startDate}/{endDate}")]
        public async Task<object> GetByETime(int eid, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetTPayrollByEmpId(eid, startDate, endDate);
                _response.Result = payrollDTO;
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
        [Route("time/{startDate}/{endDate}")]
        public async Task<object> GetByTime(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetTPayroll(startDate, endDate);
                _response.Result = payrollDTO;
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
        [Route("{eid}/month/{month}")]
        public async Task<object> GetByEMonth(int eid, int month)
        {
            try
            {
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetMPayrollByEmpId(eid, month);
                _response.Result = payrollDTO;
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
        [Route("month/{month}")]
        public async Task<object> GetByMonth(int month)
        {
            try
            {
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetMPayroll(month);
                _response.Result = payrollDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                        = new List<string>() { ex.ToString() };
            }
            return _response;
        } //done

        [HttpGet]
        [Route("empid/{eid}")]
        public async Task<object> GetByEId(int eid)
        {
            try
            {
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetPayrollByEmpId(eid);
                _response.Result = payrollDTO;
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
                List<PayrollDTO> payrollDTO = await _payrollRepository.GetPayrollByEmpName(name);
                _response.Result = payrollDTO;
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
        public async Task<object> Post([FromBody] PayrollDTO payrollDTO)
        {
            try
            {
                PayrollDTO model = await _payrollRepository.CreateUpdatePayroll(payrollDTO);
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
        public async Task<object> Put([FromBody] PayrollDTO payrollDTO)
        {
            try
            {
                PayrollDTO model = await _payrollRepository.CreateUpdatePayroll(payrollDTO);
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
                bool isSuccess = await _payrollRepository.DeletePayroll(id);
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
