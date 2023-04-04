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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<EmployeeResponseModel>> GetAsync()
        {
            return _mapper.Map<IEnumerable<EmployeeResponseModel>>(await _employeeService.GetEmployees());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeResponseModel> GetAsync(Guid id)
        {
            return _mapper.Map<EmployeeResponseModel>(await _employeeService.GetEmployee(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Guid> Post([FromBody] EmployeeRequstModel employee)
        {
            return await _employeeService.CreateEmployee(_mapper.Map<Employee>(employee));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<Guid> Put(Guid id, [FromBody] EmployeeRequstModel employee)
        {
            var mappedEmplyee = _mapper.Map<Employee>(employee);
            mappedEmplyee.Id = id;
            return await _employeeService.UpdateEmployee(_mapper.Map<Employee>(employee));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<Guid> Delete(Guid id)
        {
            return await _employeeService.DeleteEmployee(id);
        }
    }
}
