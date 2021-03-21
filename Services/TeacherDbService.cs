using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syntra.MVCAdvanced.ViewModels;

namespace Syntra.MVCAdvanced.Services
{
    public class TeacherDbService : ITeacherDbService
    {
        private readonly DanceSchoolDbContext _context;
        public TeacherDbService(DanceSchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> CreateAsync(Teacher teacherToAdd)
        {
            _context.Teachers.Add(teacherToAdd);
            await _context.SaveChangesAsync();
            return teacherToAdd;
        }

        public async Task<IEnumerable<Teacher>> GetListAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetOneAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Teacher> UpdateAsync(Teacher teacherToSave)
        {
            _context.Teachers.Update(teacherToSave);
            await _context.SaveChangesAsync();
            return teacherToSave;
        }

        public async Task<Teacher> DeleteAsync(Teacher teacherToDelete)
        {
            _context.Teachers.Remove(teacherToDelete);
            await _context.SaveChangesAsync();
            return teacherToDelete;
        }

        
    }
}
