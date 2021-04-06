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
            var stories = _context.Stories.Include(u=>u.ApplicationUser).Include(g=>g.GoogleFont).OrderByDescending(s => s.DateCreated).ToList();
            
            foreach (var s in stories)
            {
                s.ApplicationUser.PasswordHash = null;
                s.ApplicationUser.SecurityStamp = null;
                s.ApplicationUser.ConcurrencyStamp = null;
                var getLoves = _context.Loves.Where(l => l.StoryId == s.Id).Include(u=>u.ApplicationUser).ToList();
                foreach(var lo in getLoves)
                {
                    lo.ApplicationUser.PasswordHash = null;
                }
                s.Loves = getLoves;

            }
            return stories;
        }

        public List<Story> GetMyStories(string id)
        {
            var stories = _context.Stories.Where(u=>u.UserId == id).Include(g => g.GoogleFont).OrderByDescending(s => s.DateCreated).ToList();
            
            return stories;
        }

        public void WriteStory(Story story)
        {
           _context.Stories.Add(story);
           _context.SaveChanges();
        }

        public List<GoogleFont> GoogleFontList()
        {
            var googleFonts = _context.GoogleFonts.OrderByDescending(g=>g.Id).ToList();
            return googleFonts;
        }

        public Story EditMyStory(int id)
        {
            var story = new Story();
            story = _context.Stories.SingleOrDefault(s=>s.Id == id);
            if(story != null)
            {
                return story;
            }
            return story;
        }

        public Story UpdateMyStory(Story story)
        {
            var findId = _context.Stories.SingleOrDefault(s => s.Id == story.Id);
            if(findId != null)
            {
                findId.Title = story.Title;
                findId.MyStory = story.MyStory;
                findId.GoogleFontsId = story.GoogleFontsId;

                _context.SaveChanges();

                return findId;
            }
            return findId;
        }
    }
}
