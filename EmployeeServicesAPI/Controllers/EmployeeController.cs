using Microsoft.AspNetCore.Mvc;
using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Repository;

namespace EmployeeServicesAPI.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        protected ResponseDTO _response;
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTOs = await _employeeRepository.GetEmployeeList();
                _response.Result = employeeDTOs;
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
                EmployeeDTO employeeDTO = await _employeeRepository.GetEmployeeById(id);
                _response.Result = employeeDTO;
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
        [Route("ward/{wardid}")]
        public async Task<object> GetByWard(int wardid)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeByWard(wardid);
                _response.Result = employeeDTO;
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
        [Route("jobtittle/{tittleid}")]
        public async Task<object> GetByJobTittle(int tittleid)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeByJobTittle(tittleid);
                _response.Result = employeeDTO;
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
        [Route("special/{specialid}")]
        public async Task<object> GetBySpecialization(int specialid)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeBySpecialization(specialid);
                _response.Result = employeeDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        } //Done

        //[HttpGet]
        //[Route("page/{page}/size/{size}")]
        //public async Task<object> Pagination(int page, int size)
        //{
        //    try
        //    {
        //        EmployeePaginationDTO employeeDTO = await _employeeRepository.PaginationEmployeeList(page, size);
        //        _response.Result = employeeDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages
        //             = new List<string>() { ex.ToString() };
        //    }
        //    return _response;
        //}

        [HttpGet]
        [Route("nn/{nn}")]
        public async Task<object> GetByNN(string nn)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeByNN(nn);
                _response.Result = employeeDTO;
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
        [Route("snn/{snn}")]
        public async Task<object> GetBySNN(string snn)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeBySNN(snn);
                _response.Result = employeeDTO;
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
        [Route("order/{order}")]
        public async Task<object> Order(string order)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.OrderEmployee(order);
                _response.Result = employeeDTO;
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
        [Route("search/{search}")]
        public async Task<object> Search(string search)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.SearchEmployee(search);
                _response.Result = employeeDTO;
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
        [Route("empname/{fname}/{mname}/{lname}")]
        public async Task<object> GetbyName(string fname, string mname, string lname)
        {
            try
            {
                IEnumerable<EmployeeDTO> employeeDTO = await _employeeRepository.GetEmployeeByName(fname, mname, lname);
                _response.Result = employeeDTO;
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
        public async Task<object> Post([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                EmployeeDTO model = await _employeeRepository.CreateUpdateEmployee(employeeDTO);
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
        public async Task<object> Put([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                EmployeeDTO model = await _employeeRepository.CreateUpdateEmployee(employeeDTO);
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
                bool isSuccess = await _employeeRepository.DeleteEmployee(id);
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
