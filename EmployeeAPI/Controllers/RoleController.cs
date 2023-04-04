using AutoMapper;
using EmployeeAPI.RequestModels;
using EmployeeAPI.ResponseModels;
using EmployeeRole.Domain.Interfaces;
using EmployeeRole.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IEnumerable<RoleResponseModel>> Get()
        {
            return _mapper.Map<IEnumerable<RoleResponseModel>>(await _roleService.GetRoles());
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<RoleResponseModel> GetAsync(int id)
        {
            return _mapper.Map<RoleResponseModel>(await _roleService.GetRole(id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<int> Post([FromBody] RoleRequstModel role)
        {
            return await _roleService.CreateRole(_mapper.Map<Role>(role));
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<int> PutAsync(int id, [FromBody] RoleRequstModel role)
        {
            var mappedRole = _mapper.Map<Role>(role);
            mappedRole.Id = id;
            return await _roleService.UpdateRole(mappedRole);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(int id)
        {
            return await _roleService.DeleteRole(id);
        }
    }
}
