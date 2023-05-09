using AutoMapper;
using EmployeeServicesAPI.Models.DTOs;
using EmployeeServicesAPI.Models;

namespace EmployeeServicesAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDTO, Employee>().ReverseMap();
                config.CreateMap<WardDTO, Ward>().ReverseMap();
                config.CreateMap<JobTittleDTO, JobTittle>().ReverseMap();
                config.CreateMap<SpecializationDTO, Specialization>().ReverseMap();
                config.CreateMap<EmployeePaginationDTO, Employee>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
