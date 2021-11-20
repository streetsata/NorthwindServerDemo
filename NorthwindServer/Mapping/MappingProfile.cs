using AutoMapper;
using Entities.Models;
using Entities.ModelsDTOs;

namespace NorthwindServer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<CategoryForCreationDto, Category>();
        }
    }
}
