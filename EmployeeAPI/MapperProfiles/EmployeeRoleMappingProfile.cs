using AutoMapper;
using EmployeeAPI.RequestModels;
using EmployeeAPI.ResponseModels;
using EmployeeRole.Data.DataModels;
using EmployeeRole.Domain.Models;

namespace EmployeeAPI.MapperProfiles
{
    public class EmployeeRoleMappingProfile: Profile
    {
        public EmployeeRoleMappingProfile() 
        {
            CreateMap<Role, RoleResponseModel>();
            CreateMap<Employee, EmployeeResponseModel>();

            CreateMap<EmployeeRequstModel, Employee>();
            CreateMap<RoleRequstModel, Role>();

            CreateMap<Employee, EmployeeDataModel>().ReverseMap();
            CreateMap<Role, RoleDataModel>().ReverseMap();
        }
    }
}
