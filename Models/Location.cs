using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.Models
{
    public class Location 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the street.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter the street number.")]
        public string StreetNumber { get; set; }
        [Required(ErrorMessage = "Please enter the city.")]
        public string City { get; set; }
        public string Address => $"{Street} {StreetNumber} {City}";
        public List<Course> Courses { get; set; }
    }
}
