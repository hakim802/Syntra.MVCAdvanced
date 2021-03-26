using Syntra.Models;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Syntra.MVCAdvanced.ViewModels
{

    public class CourseSelectListViewModel
    {

        public Course Course { get; private set; }

        public SelectList Teachers { get; private set; }

        public SelectList Locations { get; private set; }

        public CourseSelectListViewModel(Course course,

                                        IEnumerable teachers,

                                        IEnumerable locations)
        {

            Course = course;

            Teachers = new SelectList(teachers, "TeacherID", "TeacherName", course.TeacherId);

            Locations = new SelectList(locations, "LocationID", "Name", course.LocationId);

        }

    }

}
