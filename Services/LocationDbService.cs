using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;

namespace Syntra.MVCAdvanced.Services
{
    public class LocationDbService : ILocationDbService
    {
        private readonly DanceSchoolDbContext _context;
        public LocationDbService(DanceSchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateAsync(Location locationToAdd)
        {
            _context.Locations.Add(locationToAdd);
            await _context.SaveChangesAsync();
            return locationToAdd;
        }

        public async Task<IEnumerable<Location>> GetListAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> GetOneAsync(int id)
        {
            return await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Location> UpdateAsync(Location locationToSave)
        {
            _context.Locations.Update(locationToSave);
            await _context.SaveChangesAsync();
            return locationToSave;
        }

        public async Task<Location> DeleteAsync(Location locationToDelete)
        {
            _context.Locations.Remove(locationToDelete);
            await _context.SaveChangesAsync();
            return locationToDelete;
        }
    }
}
