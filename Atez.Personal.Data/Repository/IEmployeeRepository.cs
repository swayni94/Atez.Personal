using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;

namespace Atez.Personal.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployeeAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<Employee> InsertEmployeeAsync(Employee entity);
        Task<bool> UpdateEmployeeAsync(Employee entity);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<List<Employee>> GetEmployeesInDepartmentAsync(int id);
    }
}
