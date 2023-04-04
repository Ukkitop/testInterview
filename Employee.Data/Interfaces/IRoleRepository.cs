using EmployeeRole.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDataModel>> GetRoles();
        Task<RoleDataModel> GetRole(int id);

        Task<int> CreateRole(RoleDataModel employee);

        Task<int> UpdateRole(RoleDataModel employee);

        Task<int> DeleteRole(int id);
    }
}
