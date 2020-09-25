using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;

namespace Atez.Personal.Data.Repository
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocationAsync();
        Task<Location> GetLocationAsync(int id);
        Task<Location> InsertLocationAsync(Location entity);
        Task<bool> UpdateLocationAsync(Location entity);
        Task<bool> DeleteLocationAsync(int id);
    }
}
