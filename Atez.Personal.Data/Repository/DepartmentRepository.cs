using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DatabaseContext context;
        private readonly ILogger<DepartmentRepository> logger;

        public DepartmentRepository(DatabaseContext _context, ILogger<DepartmentRepository> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await context.Departments.SingleOrDefaultAsync(c => c.id == id);
            context.Remove(department);

            try
            {
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(DeleteDepartmentAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<List<Department>> GetDepartmentAsync()
        {
            return await context.Departments.OrderBy(c => c.id).ToListAsync();
        }

        public async Task<Department> GetDepartmentAsync(int id)
        {
            return await context.Departments.SingleOrDefaultAsync(c => c.id == id);
        }

        public async Task<Department> InsertDepartmentAsync(Department entity)
        {
            context.Add(entity);

            try
            {
                await context.SaveChangesAsync();

            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(InsertDepartmentAsync)}: " + exp.Message);
            }
            return entity;
        }

        public async Task<bool> UpdateDepartmentAsync(Department entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.UpdatedId = entity.id;
            context.Departments.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            try
            {
                return (await context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                logger.LogError($"Error in {nameof(UpdateDepartmentAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
