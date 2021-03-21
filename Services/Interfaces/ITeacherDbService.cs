using System.Collections.Generic;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.Services.Interfaces
{
    public interface ITeacherDbService
    {
        Task<Teacher> CreateAsync(Teacher teacherToAdd);
        //Task<Teacher> FindAsync(string searchString);
        Task<IEnumerable<Teacher>> GetListAsync();
        Task<Teacher> GetOneAsync(int id);
        Task<Teacher> UpdateAsync(Teacher teacherToSave);
        Task<Teacher> DeleteAsync(Teacher teacherToDelete);
    }
}