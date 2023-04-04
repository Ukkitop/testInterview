using EmployeeRole.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.DataModels
{
    public class EmployeeDataModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<RoleDataModel> Roles { get; set; }
    }
}
