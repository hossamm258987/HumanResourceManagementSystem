using AutoMapper;
using PayRollServicesAPI.Models.DTOs;
using PayRollServicesAPI.Models;

namespace PayRollServicesAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                config.CreateMap<AttendanceDTO, Attendance>().ReverseMap();
                config.CreateMap<DeductionDTO, Deduction>().ReverseMap();
                config.CreateMap<PayrollDTO, Payroll>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
