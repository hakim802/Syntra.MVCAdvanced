using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syntra.Models;
using Syntra.MVCAdvanced.Services.Interfaces;
using Syntra.MVCAdvanced.ViewModels;
using AutoMapper;
using Syntra.MVCAdvanced.Services;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Syntra.MVCAdvanced.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseDbService _courseService = null;
        private readonly ITeacherDbService _teacherService = null;
        private readonly ILocationDbService _locationService = null;
        private readonly IMapper _mapper;

        public CourseController(ICourseDbService courseDbService, ITeacherDbService teacherDbService, ILocationDbService locationDbService, IMapper mapper)
        {
            _courseService = courseDbService;
            _teacherService = teacherDbService;
            _locationService = locationDbService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Create()
        {
            CourseDetailsVM courseMV = new CourseDetailsVM
            {
                Teachers = await _teacherService.GetListAsync(),
                Locations = await _locationService.GetListAsync()
            };
            return View(courseMV);
        }
        //public IActionResult Create()
        //{
        //    SetTeacherLocationViewBag();
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, DateTime, TeacherId, LocationId")] CourseDetailsVM courseMV)
        {
            if (ModelState.IsValid)
            {
                
                var courseToAdd = _mapper.Map<Course>(courseMV);
                var course = await _courseService.CreateAsync(courseToAdd);
                var courseVMToAdd = _mapper.Map<CourseDetailsVM>(course);
                 
                return RedirectToAction(nameof(Index));
            }
            return View(courseMV);
        }

        public async Task<IActionResult> Index(string searchString)

        {
            var courses = await _courseService.GetListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Name.Contains(searchString)).ToList();
            }

            var courseVM = new CourseDetailsVM
            {
                Courses = courses.OrderBy(a => a.DateTime).ToList()
            };
            return View(courseVM);
        }

        private async void SetTeacherLocationViewBag(int? TeacherID = null, int? LocationID = null)
        {
            CourseDetailsVM courseMV = new CourseDetailsVM
            {
                Teachers = await _teacherService.GetListAsync(),
                Locations = await _locationService.GetListAsync()
            };
            //var locationsFromDb = await _locationService.GetListAsync();
            //var locationVM = _mapper.Map<LocationDetailsVM>(locationsFromDb);
            //var teachersFromDb = await _teacherService.GetListAsync();
            //var teacherVM = _mapper.Map<TeacherDetailsVM>(teachersFromDb);
            //if (TeacherID == null)
              
            //    ViewBag.Teachers = new SelectList(courseMV.Teachers.ToList(), "Id", "TeacherName");
            //else
            //    ViewBag.Teachers = new SelectList(courseMV.Teachers.ToList(), "Id", "TeacherName", TeacherID.Value);

            if (LocationID == null)

                ViewBag.Locations = new SelectList(courseMV.Locations.ToList(), "Id", "Street");
            else
                ViewBag.Locations = new SelectList(courseMV.Locations.ToList(), "Id", "Street");

        }

        public async Task<IActionResult> Edit(int id)
        {
            //if (courseFromDb == null)
            //{
            //    return NotFound();
            //}
            //CourseDetailsVM courseVM = new CourseDetailsVM
            //{
            //    Teachers = await _teacherService.GetListAsync(),
            //    Locations = await _locationService.GetListAsync()
            //};
            //var courseFromDb = await _courseService.GetOneAsync(id);
            //if (courseFromDb == null)
            //{
            //    return NotFound();
            //}
            //var courseV = _mapper.Map<CourseDetailsVM>(courseFromDb);
            
            Course courseFromDb = await _courseService.GetOneAsync(id);
            SetTeacherLocationViewBag(courseFromDb.TeacherId, courseFromDb.LocationId);
            return View(courseFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Name, DateTime, TeacherId, LocationId")] CourseDetailsVM courseVM)
        {

            if (ModelState.IsValid) //is het valid?
            {
                var courseToUpdate = _mapper.Map<Course>(courseVM);
                var updatedCourse = await _courseService.UpdateAsync(courseToUpdate);
                var courseVMToReturn = _mapper.Map<CourseDetailsVM>(updatedCourse);
                return RedirectToAction(nameof(Index));
            }
            return View(courseVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var courseFromDb = await _courseService.GetOneAsync(id);
            if (courseFromDb == null)
            {
                return NotFound();
            }
            var courseVM = _mapper.Map<CourseDetailsVM>(courseFromDb);
            return View(courseFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(CourseDetailsVM courseVM)
        {
            var courseToDelete = _mapper.Map<Course>(courseVM);
            var course = await _courseService.DeleteAsync(courseToDelete);
            return RedirectToAction(nameof(Index));
        }

        //public async Task<ActionResult> EditVM(int id)
        //{
        //    Course course = await _courseService.GetOneAsync(id);
        //    if (course == null)
        //        return NotFound();
        //    CourseSelectListViewModel aslvm = new CourseSelectListViewModel(course, await _teacherService.GetListAsync(), await _locationService.GetListAsync());
        //    return View(aslvm);
        //}
    }
}
