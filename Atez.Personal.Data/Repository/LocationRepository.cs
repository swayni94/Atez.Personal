using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Data.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DatabaseContext context;
        private readonly ILogger<LocationRepository> logger;

        public LocationRepository(DatabaseContext _context, ILogger<LocationRepository> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = context.Locations.SingleOrDefaultAsync(c => c.id == id);
            context.Remove(location);

            try
            {
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(DeleteLocationAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<List<Location>> GetLocationAsync()
        {
            return await context.Locations.OrderBy(c => c.id).ToListAsync();
        }

        public async Task<Location> GetLocationAsync(int id)
        {
            return await context.Locations.SingleOrDefaultAsync(c => c.id == id);
        }

        public async Task<Location> InsertLocationAsync(Location entity)
        {
            context.Add(entity);

            try
            {

                await context.SaveChangesAsync();

            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(InsertLocationAsync)}: " + exp.Message);
            }
            return entity;
        }

        public async Task<bool> UpdateLocationAsync(Location entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.UpdatedId = entity.id;
            context.Locations.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            try
            {
                return (await context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                logger.LogError($"Error in {nameof(UpdateLocationAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
