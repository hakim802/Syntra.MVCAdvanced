using AutoMapper;
using Syntra.Models;
using Syntra.MVCAdvanced.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syntra.MVCAdvanced.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDetailsVM>()
                .ReverseMap();
        }
    }
}