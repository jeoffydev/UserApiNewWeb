using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Data;
using UserApiNewWeb.Models;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Repository
{
    public class StoryService : IStoryRepository
    {
        private ApplicationDbContext _context;

        public StoryService(ApplicationDbContext db)
        {
            _context = db;
        }
        public List<Story> GetStories()
        {
            //var stories = _context.Stories.Select(sel=> new Story(){ Id = sel.Id, Title = sel.Title, MyStory = sel.MyStory } ).OrderBy(s => s.Id).ToList();
            var stories = _context.Stories.Include(u=>u.ApplicationUser).OrderBy(s => s.Id).ToList();
            return stories;
        }

        public List<Story> GetMyStories(string id)
        {
            var stories = _context.Stories.Where(u=>u.UserId == id).ToList();
            return stories;
        }

        public void WriteStory(Story story)
        {
           _context.Stories.Add(story);
           _context.SaveChanges();
        }
    }
}
