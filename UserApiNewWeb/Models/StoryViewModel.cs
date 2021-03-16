﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class StoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string MyStory { get; set; }
        public string FontAwesome { get; set; } 
        public string BackgroundColour { get; set; }
        [Required]
        public string UserId { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
