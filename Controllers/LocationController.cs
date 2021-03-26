using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Syntra.Models;
using Syntra.MVCAdvanced.Services.Interfaces;
using Syntra.MVCAdvanced.ViewModels;

namespace Syntra.MVCAdvanced.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationDbService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationDbService locationDbService, IMapper mapper)
        {
            _locationService = locationDbService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,StreetNumber,City")] Location locationVM)
        {
            if (ModelState.IsValid)
            {
                var locationToAdd = _mapper.Map<Location>(locationVM); // maak van de vm een teacher object
                var location = await _locationService.CreateAsync(locationToAdd); // geef het teacher object mee aan de create functie
                var locationVMToAdd = _mapper.Map<LocationDetailsVM>(location); // map de gecreëerd teacher terug naar een VM
                return RedirectToAction(nameof(Index)); //return View(teacherVMToReturn); // return de view  met de VM
            }
            return View(locationVM); // De view was niet valid, maak opnieuw de view met de invalid teacherVM
        }

        public async Task<IActionResult> Index(string searchString)

        {
            var locations = await _locationService.GetListAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                locations = locations.Where(s => s.Street.Contains(searchString) || s.City.Contains(searchString));
            }

            var locationVM = new LocationDetailsVM
            {
                Locations = locations.ToList()
            };
            return View(locationVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var locationFromDb = await _locationService.GetOneAsync(id);
            if (locationFromDb == null)
            {
                return NotFound();
            }
            var locationVM = _mapper.Map<LocationDetailsVM>(locationFromDb);
            return View(locationVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var locationFromDb = await _locationService.GetOneAsync(id);
            if (locationFromDb == null)
            {
                return NotFound();
            }
            var locationVM = _mapper.Map<LocationDetailsVM>(locationFromDb);
            return View(locationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Street,StreetNumber,City")] LocationDetailsVM locationVM)
        {

            if (ModelState.IsValid) //is het valid?
            {
                var locationToUpdate = _mapper.Map<Location>(locationVM);
                var updatedLocation = await _locationService.UpdateAsync(locationToUpdate);
                var locationVMToReturn = _mapper.Map<LocationDetailsVM>(updatedLocation);
                return RedirectToAction(nameof(Index));
            }
            return View(locationVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var locationFromDb = await _locationService.GetOneAsync(id);
            if (locationFromDb == null)
            {
                return NotFound();
            }
            var teacherVM = _mapper.Map<LocationDetailsVM>(locationFromDb);
            return View(locationFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(LocationDetailsVM locationVM)
        {
            var locationToDelete = _mapper.Map<Location>(locationVM);
            var location = await _locationService.DeleteAsync(locationToDelete);
            return RedirectToAction(nameof(Index));
        }
    }
}
