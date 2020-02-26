using AutoMapper;
using Shop.Domain.Core;
using Shop.Models;

namespace Shop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeOutputViewModel>().ReverseMap();
        }
    }
}