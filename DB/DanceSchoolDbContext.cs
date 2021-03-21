using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;

namespace Syntra.MVCAdvanced.DB
{
    public class DanceSchoolDbContext : DbContext
    {
        public DanceSchoolDbContext(DbContextOptions<DanceSchoolDbContext> options)
            : base(options)
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
