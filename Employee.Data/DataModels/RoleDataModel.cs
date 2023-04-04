using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.DataModels
{
    public class RoleDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Grade { get; set; }

        public IList<EmployeeDataModel> Employees { get; set; }
    }
}
