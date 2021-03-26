using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Syntra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.DB
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<DanceSchoolDbContext>>();
            using (var context = new DanceSchoolDbContext(dbContextOptions))
            {
                if (context.Teachers.Count() == 0)
                {
                    var teacher1 = new Teacher();
                    teacher1.FirstName = "Bjorn";
                    teacher1.LastName = "Lecis";
                    teacher1.Salary = 1200;
                    var teacher2 = new Teacher();
                    teacher2.FirstName = "Maxim";
                    teacher2.LastName = "Crabbé";
                    teacher2.Salary = 1500;
                    context.Add(teacher1);
                    context.Add(teacher2);
                    context.SaveChanges();
                }

            }
        }
    }
}