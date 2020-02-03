using AutoMapper;
using BinhProjectMain.Dto;
using BinhProjectMain.Models;

namespace BinhProjectMain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomerDto>();
            CreateMap<Orders, OrderDto>();
            CreateMap<Employees, EmployeeDto>();
        }
    }
}
