using AutoMapper;
using EmployeeRole.Data.DataModels;
using EmployeeRole.Data.Interfaces;
using EmployeeRole.Domain.Interfaces;
using EmployeeRole.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public Task<int> CreateRole(Role role)
        {
           return _roleRepository.CreateRole(_mapper.Map<RoleDataModel>(role));
        }

        public async Task<int> DeleteRole(int id)
        {
            return await _roleRepository.DeleteRole(id);
        }

        public async Task<Role> GetRole(int id)
        {
            return _mapper.Map<Role>(await _roleRepository.GetRole(id));
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return _mapper.Map<IEnumerable<Role>>(await _roleRepository.GetRoles());
        }

        public Task<int> UpdateRole(Role role)
        {
            return _roleRepository.UpdateRole(_mapper.Map<RoleDataModel>(role));
        }
    }
}
