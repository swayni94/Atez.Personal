using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;

namespace Atez.Personal.Data.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartmentAsync();
        Task<Department> GetDepartmentAsync(int id);
        Task<Department> InsertDepartmentAsync(Department entity);
        Task<bool> UpdateDepartmentAsync(Department entity);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
