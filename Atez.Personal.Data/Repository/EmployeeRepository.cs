using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext context;
        private readonly ILogger<EmployeeRepository> logger;

        public EmployeeRepository(DatabaseContext _context, ILogger<EmployeeRepository> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = context.Employees.SingleOrDefaultAsync(c => c.id == id);
            context.Remove(employee);

            try {
                return await context.SaveChangesAsync() > 0 ? true : false; 
            }
            catch (System.Exception exp)
            {
               logger.LogError($"Error in {nameof(DeleteEmployeeAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await context.Employees.OrderBy(c => c.id).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await context.Employees.SingleOrDefaultAsync(c => c.id == id);
        }
        
        public async Task<Employee> GetEmployeeOfTitleDateListAsync(int employeeId)
        {
            // return await context.Employees.SingleOrDefaultAsync(c => c.id == employeeId).;
            //düzenlemeyi unutma!
            return await context.Employees.SingleOrDefaultAsync(c => c.id == employeeId);
        }

        public async Task<List<Employee>> GetEmployeesInDepartmentAsync(int departmentId)
        {
            return await context.Employees.Include(c => c.departmentid == departmentId).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesInManagerAsync(int managerId)
        {
            //??????????Düzenle
            var entity = context.Departments.SingleOrDefaultAsync(c => c.managerid == managerId);
            return await context.Employees.Include(c => c.departmentid == entity.Id).ToListAsync();
        }

        public async Task<Employee> InsertEmployeeAsync(Employee entity)
        {
            context.Add(entity);

            try
            {

                await context.SaveChangesAsync();

            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(InsertEmployeeAsync)}: " + exp.Message);
            }
            return entity;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.UpdatedId = entity.id;
            context.Employees.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            try
            {
                return (await context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                logger.LogError($"Error in {nameof(UpdateEmployeeAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> UpdateEmployeeOfTitleAsync(int id, int titleId)
        {
            var entity = await context.Employees.SingleOrDefaultAsync(c => c.id == id);
            entity.titleid = titleId;

            context.Employees.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            try
            {
                return (await context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                logger.LogError($"Error in {nameof(UpdateEmployeeAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
