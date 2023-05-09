using Microsoft.AspNetCore.Mvc;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Repository;

namespace PayRollServicesAPI.Controllers
{
    [Route("api/attendance")]
    public class AttendanceController : ControllerBase
    {
        protected ResponseDTO _response;
        private IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<AttendanceDTO> attendanceDTOs = await _attendanceRepository.GetAttendanceList();
                _response.Result = attendanceDTOs;
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
                AttendanceDTO attendanceDTO = await _attendanceRepository.GetAttendanceById(id);
                _response.Result = attendanceDTO;
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
        public async Task<object> Get(int eid, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<AttendanceDTO> attendanceDTO = await _attendanceRepository.GetTAttendanceByEmpId(eid, startDate, endDate);
                _response.Result = attendanceDTO;
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
        public async Task<object> Get(int eid, int month)
        {
            try
            {
                List<AttendanceDTO> attendanceDTO = await _attendanceRepository.GetMAttendanceByEmpId(eid, month);
                _response.Result = attendanceDTO;
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
        [Route("empid/{eid}")]
        public async Task<object> GetByEId(int eid)
        {
            try
            {
                List<AttendanceDTO> attendanceDTO = await _attendanceRepository.GetAttendanceByEmpId(eid);
                _response.Result = attendanceDTO;
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
                List<AttendanceDTO> attendanceDTO = await _attendanceRepository.GetAttendanceByEmpName(name);
                _response.Result = attendanceDTO;
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
        public async Task<object> Post([FromBody] AttendanceDTO attendanceDTO)
        {
            try
            {
                AttendanceDTO model = await _attendanceRepository.CreateUpdateAttendance(attendanceDTO);
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
        public async Task<object> Put([FromBody] AttendanceDTO attendanceDTO)
        {
            try
            {
                AttendanceDTO model = await _attendanceRepository.CreateUpdateAttendance(attendanceDTO);
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
                bool isSuccess = await _attendanceRepository.DeleteAttendance(id);
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
