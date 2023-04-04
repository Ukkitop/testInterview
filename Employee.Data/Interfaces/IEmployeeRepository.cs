using EmployeeRole.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDataModel>> GetEmployees();
        Task<EmployeeDataModel> GetEmployee(Guid id);

        Task<Guid> CreateEmployee(EmployeeDataModel employee);

        Task<Guid> UpdateEmployee(EmployeeDataModel employee);

        Task<Guid> DeleteEmployee(Guid id);
    }
}
