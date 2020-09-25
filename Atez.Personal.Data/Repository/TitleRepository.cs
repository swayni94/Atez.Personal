using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atez.Personal.Data.Repository
{
    public class TitleRepository : ITitleRepository
    {
        private readonly DatabaseContext context;
        private readonly ILogger<TitleRepository> logger;

        public TitleRepository(DatabaseContext _context, ILogger<TitleRepository> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public async Task<bool> DeleteTitleAsync(int id)
        {
            var title = context.Locations.SingleOrDefaultAsync(c => c.id == id);
            context.Remove(title);

            try
            {
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(DeleteTitleAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<List<Title>> GetTitleAsync()
        {
            return await context.Titles.OrderBy(c => c.id).ToListAsync();
        }

        public async Task<Title> GetTitleAsync(int id)
        {
            return await context.Titles.SingleOrDefaultAsync(c => c.id == id);
        }

        public async Task<Title> InsertTitleAsync(Title entity)
        {
            context.Add(entity);

            try
            {
                await context.SaveChangesAsync();

            }
            catch (System.Exception exp)
            {
                logger.LogError($"Error in {nameof(InsertTitleAsync)}: " + exp.Message);
            }
            return entity;
        }

        public async Task<bool> UpdateTitleAsync(Title entity)
        {
            entity.UpdatedDateTime = DateTime.UtcNow;
            entity.UpdatedId = entity.id;
            context.Titles.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            try
            {
                return (await context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                logger.LogError($"Error in {nameof(UpdateTitleAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
