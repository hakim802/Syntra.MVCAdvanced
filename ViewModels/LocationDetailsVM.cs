using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syntra.Models;

namespace Syntra.MVCAdvanced.ViewModels
{
    public class LocationDetailsVM
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public List<Location> Locations { get; set; }
        public string SearchString { get; set; }
    }
}
