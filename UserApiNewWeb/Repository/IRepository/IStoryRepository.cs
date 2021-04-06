﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;

namespace UserApiNewWeb.Repository.IRepository
{
    public interface IStoryRepository
    {
        List<Story> GetStories();
        List<Story> GetMyStories(string id);
        void WriteStory(Story story); 
        List<GoogleFont> GoogleFontList();

        Story EditMyStory(int id);

        Story UpdateMyStory(Story story);
    }
}
