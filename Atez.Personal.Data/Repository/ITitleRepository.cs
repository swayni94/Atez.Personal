using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atez.Personal.Data.Entity;

namespace Atez.Personal.Data.Repository
{
    public interface ITitleRepository
    {
        Task<List<Title>> GetTitleAsync();
        Task<Title> GetTitleAsync(int id);
        Task<Title> InsertTitleAsync(Title entity);
        Task<bool> UpdateTitleAsync(Title entity);
        Task<bool> DeleteTitleAsync(int id);
    }
}
