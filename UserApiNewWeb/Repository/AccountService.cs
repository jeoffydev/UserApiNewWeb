using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserApiNewWeb.Data;
using UserApiNewWeb.Jwt;
using UserApiNewWeb.Models;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Repository
{
    public class AccountService : IAccountRepository
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<IdentityUser> _signInManager;
        private AppSettings _appsettings;
        private ApplicationDbContext _context;

        public AccountService(UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager, SignInManager<IdentityUser> signinmanager, IOptions<AppSettings> appsettings, ApplicationDbContext db)
        {
            _userManager = usermanager;
            _roleManager = rolemanager;
            _signInManager = signinmanager;
            _appsettings = appsettings.Value;
            _context = db;

        }
        public ApplicationUser Login(ApplicationUser login)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(u => u.UserName == login.UserName);
            user.PasswordHash = null; 

             return user;
        }
    }
}
