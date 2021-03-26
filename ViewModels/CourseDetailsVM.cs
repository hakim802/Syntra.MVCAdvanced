using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class CourseDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public List<Course> Courses { get; set; }
        public string SearchString { get; set; }
    }
}
