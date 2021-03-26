using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syntra.Models;
using Syntra.MVCAdvanced.DB;
using Syntra.MVCAdvanced.Services.Interfaces;
using Syntra.MVCAdvanced.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherDbService _teacherService;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherDbService teacherDbService, IMapper mapper)
        {
            _teacherService = teacherDbService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Salary")] Teacher teacherVM)
        {
            if (teacherVM.FirstName == teacherVM.LastName)
            {
                ModelState.AddModelError("LastName",
                                         "The last name cannot be the same as the first name.");
            }
                if (ModelState.IsValid)
            {
                var teacherToAdd = _mapper.Map<Teacher>(teacherVM); // maak van de vm een teacher object
                var teacher = await _teacherService.CreateAsync(teacherToAdd); // geef het teacher object mee aan de create functie
                //var teacherVMToAdd = _mapper.Map<TeacherDetailsVM>(teacher); // map de gecreëerd teacher terug naar een VM
                return RedirectToAction(nameof(Index)); //return View(teacherVMToReturn); // return de view  met de VM
            }
            return View(teacherVM); // De view was niet valid, maak opnieuw de view met de invalid teacherVM
        }

        public async Task<IActionResult> Index(string searchString)
        
        {
            var teachers = await _teacherService.GetListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(s => s.FirstName.Contains(searchString)|| s.LastName.Contains(searchString));
            }

            var teacherVM = new TeacherDetailsVM
            {
                Teachers =  teachers.ToList()
            };
            return View(teacherVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacherFromDb = await _teacherService.GetOneAsync(id);
            if (teacherFromDb == null)
            {
                return NotFound();
            }
            var teacherVM = _mapper.Map<TeacherDetailsVM>(teacherFromDb);
            return View(teacherVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var teacherFromDb = await _teacherService.GetOneAsync(id);
            if (teacherFromDb == null)
            {
                return NotFound();
            }
            var teacherVM = _mapper.Map<TeacherDetailsVM>(teacherFromDb);
            return View(teacherVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,FirstName,LastName,Salary")] TeacherDetailsVM teacherVM)
        {

            if (ModelState.IsValid) //is het valid?
            {
                var teacherToUpdate = _mapper.Map<Teacher>(teacherVM);
                var updatedTeacher = await _teacherService.UpdateAsync(teacherToUpdate);
                //var teacherVMToReturn = _mapper.Map<TeacherDetailsVM>(updatedTeacher);
                return RedirectToAction(nameof(Index)); 
            }
            return View(teacherVM); 
        }

        public async Task<IActionResult> Delete(int id )
        {
            var teacherFromDb = await _teacherService.GetOneAsync(id);
            if (teacherFromDb == null)
            {
                return NotFound();
            }
            var teacherVM = _mapper.Map<TeacherDetailsVM>(teacherFromDb);
            return View(teacherFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(TeacherDetailsVM teacherVM)
        {
            var teacherToDelete = _mapper.Map<Teacher>(teacherVM);
            var teacher = await _teacherService.DeleteAsync(teacherToDelete);
            return RedirectToAction(nameof(Index));
        }
    }
}