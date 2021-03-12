using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;

namespace UserApiNewWeb.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
            CreateMap<Story, StoryViewModel>().ReverseMap();
        }
    }
}
