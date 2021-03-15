using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MyStory { get; set; }
        public string FontAwesome { get; set; } 
        public string BackgroundColour { get; set; }
    }
}
