using System.Collections.Generic;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ICourseDbService
    {
        Task<Course> CreateAsync(Course courseToAdd);
        Task<Course> DeleteAsync(Course courseToDelete);
        Task<List<Course>> GetListAsync();
        Task<Course> GetOneAsync(int id);
        Task<Course> UpdateAsync(Course courseToSave);
    }
}