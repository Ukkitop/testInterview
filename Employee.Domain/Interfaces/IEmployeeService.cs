using EmployeeRole.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid id);

        Task<Guid> CreateEmployee(Employee employee);

        Task<Guid> UpdateEmployee(Employee employee);

        Task<Guid> DeleteEmployee(Guid id);
    }
}
