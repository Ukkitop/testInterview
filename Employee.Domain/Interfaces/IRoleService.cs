using EmployeeRole.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRole(int id);

        Task<int> CreateRole(Role employee);

        Task<int> UpdateRole(Role employee);

        Task<int> DeleteRole(int id);
    }
}
