using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Data;
using UserApiNewWeb.Models;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Repository
{
    public class LoveService : ILoveRepository
    {
        private ApplicationDbContext _context;
        public LoveService(ApplicationDbContext db)
        {
            _context = db;
        }
        public bool CreateLove(string userid, int storyid)
        {

            var exist = _context.Loves.SingleOrDefault(u => u.UserId == userid && u.StoryId == storyid);
            if (exist == null)
            {
                var newLove = new Love()
                {
                    UserId = userid,
                    StoryId = storyid
                };
                _context.Add(newLove);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        public int DeleteLove(string userid, int storyid)
        {
            var exist = _context.Loves.SingleOrDefault(u => u.UserId == userid && u.StoryId == storyid);
            if (exist != null)
            {
                _context.Loves.Remove(exist);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
