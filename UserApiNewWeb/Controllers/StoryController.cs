using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Controllers
{
    public class StoryController : Controller
    {
        private IStoryRepository _storyRepo;
        private IMapper _imapper;

        public StoryController(IStoryRepository storyrepo, IMapper mapper)
        {
            _storyRepo = storyrepo;
            _imapper = mapper;
        }

        [Route("api/story")]
        [HttpGet]
        public IActionResult TestApi()
        {
            return Ok("Okay Story");
        }

        [Authorize]
        [HttpGet]
        [Route("api/stories")]
        public List<StoryViewModel> GetAllStories()
        {
            var stories =  _storyRepo.GetStories();
            var storiesDto = _imapper.Map<List<StoryViewModel>>(stories);

            return storiesDto;
        }

    }
}
