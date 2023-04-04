using EmployeeRole.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EmployeeDataModel> Employees { get; set; }
        public DbSet<RoleDataModel> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    }
}
