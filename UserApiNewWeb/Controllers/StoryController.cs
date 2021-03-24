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

        
        [HttpGet]
        [Route("api/stories")]
        public List<StoryViewModel> GetAllStories()
        {
            var stories =  _storyRepo.GetStories();
            var storiesDto = _imapper.Map<List<StoryViewModel>>(stories);

            return storiesDto;
        }

        [Authorize]
        [HttpGet]
        [Route("api/stories/{user}")]
        public List<StoryViewModel> GetMyStories(string user)
        {
            var stories = _storyRepo.GetMyStories(user);
            var storiesDto = _imapper.Map<List<StoryViewModel>>(stories);

            return storiesDto;
        }

        


        [Route("api/stories")]
        [HttpPost] 
        public  IActionResult  PostMyStory([FromBody] StoryViewModel story)
        {
            if (story.Title == null || story.MyStory == null || story.UserId == null)
            {
                return BadRequest(new { error = ModelState });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = ModelState });
            }

            var storyDto = new StoryViewModel()
            {
                Title = story.Title,
                MyStory = story.MyStory,
                GoogleFontsId = story.GoogleFontsId,
                BackgroundColour = story.BackgroundColour,
                UserId = story.UserId,
                DateCreated = DateTime.Now
            
            }; 
            var writeDto = _imapper.Map<Story>(storyDto);
            _storyRepo.WriteStory(writeDto); 

            return Ok( new { message="success" }); 
            
        }


        [HttpGet]
        [Route("api/googlefonts")]
        public List<GoogleFont> GetGoogleFonts()
        {
            var googleFonts = _storyRepo.GoogleFontList(); 
            return googleFonts;
        }



    }
}
