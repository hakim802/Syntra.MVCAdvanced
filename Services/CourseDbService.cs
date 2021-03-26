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
    public class CourseDbService : ICourseDbService
    {
        private readonly DanceSchoolDbContext _context;
        public CourseDbService(DanceSchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Course> CreateAsync(Course courseToAdd)
        {
            _context.Courses.Add(courseToAdd);
            await _context.SaveChangesAsync();
            return courseToAdd;
        }

        public async Task<List<Course>> GetListAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetOneAsync(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Course> UpdateAsync(Course courseToSave)
        {
            _context.Courses.Update(courseToSave);
            await _context.SaveChangesAsync();
            return courseToSave;
        }

        public async Task<Course> DeleteAsync(Course courseToDelete)
        {
            _context.Courses.Remove(courseToDelete);
            await _context.SaveChangesAsync();
            return courseToDelete;
        }
    }
}
