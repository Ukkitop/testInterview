using EmployeeRole.Data.DataModels;
using EmployeeRole.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateEmployee(EmployeeDataModel employee)
        {
            var roleEntitiesList = new List<RoleDataModel>();
            var roles = await _context.Roles.ToListAsync();
            foreach (var role in employee.Roles)
            {
                var roleEntity = roles.FirstOrDefault(x => x.Id == role.Id);
                if(roleEntity != null)
                {
                    roleEntitiesList.Add(roleEntity);
                }
            }
            employee.Roles = roleEntitiesList;
            var entity = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<Guid> DeleteEmployee(Guid id)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _context.Employees.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public async Task<EmployeeDataModel> GetEmployee(Guid id)
        {
            return await _context.Employees.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<EmployeeDataModel>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Guid> UpdateEmployee(EmployeeDataModel employee)
        {
            var entity = await _context.Employees.Include(x => x.Roles).FirstOrDefaultAsync(x => x.Id == employee.Id);
            
            if (entity != null)
            {
                var roleEntitiesList = new List<RoleDataModel>();
                var roles = await _context.Roles.ToListAsync();
                foreach (var role in employee.Roles)
                {
                    var roleEntity = roles.FirstOrDefault(x => x.Id == role.Id);
                    if (roleEntity != null)
                    {
                        roleEntitiesList.Add(roleEntity);
                    }
                }
                entity.Name = employee.Name;
                var removedRoles = entity.Roles.Where(x => roleEntitiesList.FirstOrDefault(y => x.Id == y.Id) == null).ToList();
                foreach(var role in removedRoles)
                {
                entity.Roles.Remove(role);
                }

                var addedRoles = roleEntitiesList.Where(x => entity.Roles.FirstOrDefault(y => x.Id == y.Id) == null).ToList();
                foreach (var role in addedRoles)
                {
                    entity.Roles.Add(role);
                }
                _context.Employees.Update(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
