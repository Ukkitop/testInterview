using AutoMapper;
using EmployeeRole.Data.DataModels;
using EmployeeRole.Data.Interfaces;
using EmployeeRole.Data.Repositories;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateEmployee(Employee employee)
        {
            return await _employeeRepository.CreateEmployee(_mapper.Map<EmployeeDataModel>(employee));
        }

        public async Task<Guid> DeleteEmployee(Guid id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            return _mapper.Map<Employee>(await _employeeRepository.GetEmployee(id));
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return _mapper.Map<IEnumerable<Employee>>(await _employeeRepository.GetEmployees());
        }

        public async Task<Guid> UpdateEmployee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(_mapper.Map<EmployeeDataModel>(employee));
        }
    }
}
