using EmployeeRole.Data.DataModels;
using EmployeeRole.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRole.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRole(RoleDataModel role)
        {
            var entity = await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<int> DeleteRole(int id)
        {
            var entity = await _context.Roles.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
            if(entity != null && entity.Employees.IsNullOrEmpty())
            {
                _context.Roles.Remove(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new NullReferenceException();
            }            
        }

        public async Task<RoleDataModel> GetRole(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<RoleDataModel>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<int> UpdateRole(RoleDataModel role)
        {
            var entity = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);
            if (entity != null)
            {
                entity.Name = role.Name;
                entity.Grade = role.Grade;
                _context.Roles.Update(entity);
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
