using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Syntra.Models;
using Syntra.MVCAdvanced.ViewModels;

namespace Syntra.MVCAdvanced.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationDetailsVM>()
                .ReverseMap();
        }
    }
}
