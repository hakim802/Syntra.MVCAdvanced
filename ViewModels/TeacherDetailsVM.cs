using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class TeacherDetailsVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public List<Teacher> Teachers { get; set; }
        public string SearchString { get; set; }
    }
}