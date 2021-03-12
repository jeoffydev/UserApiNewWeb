﻿using System;
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
            var stories = _context.Stories.OrderBy(s => s.Id).ToList();
            return stories;
        }
    }
}
