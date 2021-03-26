using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the user's first name.")]
        [StringLength(20, ErrorMessage = "The FirstName must be less than {1} characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the user's last name.")]
        [StringLength(20, ErrorMessage = "The LastName must be less than {1} characters.")]
        public string LastName { get; set; }
        public string TeacherName => $"{FirstName} {LastName}";
        [Range(100, 2000)]
        public double Salary { get; set; }
        public List<Course> Courses { get; set; }
    }
}
