using System.Collections.Generic;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ILocationDbService
    {
        Task<Location> CreateAsync(Location locationToAdd);
        Task<Location> DeleteAsync(Location locationToDelete);
        Task<IEnumerable<Location>> GetListAsync();
        Task<Location> GetOneAsync(int id);
        Task<Location> UpdateAsync(Location locationToSave);
    }
}