﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserApiNewWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        [NotMapped]
        public string Token { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
