using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
using UserApiNewWeb.Repository;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Controllers
{
   
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        //private AccountService _accountservice;
        private IAccountRepository _IaccountRepo;
        private IMapper _imapper;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<IdentityUser> _signInManager;
        private AppSettings _appsettings;
        private ApplicationDbContext _context;

        public AccountApiController( IAccountRepository iaccountrepository, IMapper mapper, UserManager<IdentityUser> usermanager, RoleManager<IdentityRole> rolemanager, SignInManager<IdentityUser> signinmanager, IOptions<AppSettings> appsettings, ApplicationDbContext db)
        {
            //_accountservice = accountservice;
            _IaccountRepo = iaccountrepository;
            _imapper = mapper;

            _userManager = usermanager;
            _roleManager = rolemanager;
            _signInManager = signinmanager;
            _appsettings = appsettings.Value;
            _context = db;
        }




        [Route("api/test")]
        [HttpGet]
        public  IActionResult  TestApi()
        {
            return Ok("Okay to edit"); 
        }




         [HttpPost]
         [Route("api/login")]
         public async Task<IActionResult> Login([FromBody] LoginViewModel login)
         {
            var appError = new ApplicationUser();
            appError.UserName = null;
            appError.Id = null;

            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = ModelState });
            }

            if (ModelState.IsValid)
             {

               
                 var res = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
                 if (res.Succeeded)
                 {
                     var userDto = _imapper.Map<ApplicationUser>(login);
                     var user = _IaccountRepo.Login(userDto);

                    //Get the role of the user

                     //var roles = await _userManager.GetRolesAsync(user);
                     if(await _userManager.IsInRoleAsync(user, "Admin")){
                        user.Role = "Admin";
                     }

                    if (await _userManager.IsInRoleAsync(user, "User")){
                        user.Role = "User";
                    }

                    //JWT

                    var tokenHandler = new JwtSecurityTokenHandler();
                     var key = System.Text.Encoding.ASCII.GetBytes(_appsettings.Secret);
                     var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor()
                     {
                         Subject = new ClaimsIdentity(new Claim[] {
                             new Claim(ClaimTypes.Name, user.Id),
                             new Claim(ClaimTypes.Email, user.UserName),
                             new Claim(ClaimTypes.Role, user.Role)
,                         }),
                         Expires = DateTime.UtcNow.AddHours(1),
                         SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
                     };
                     var token = tokenHandler.CreateToken(tokenDescriptor);
                     user.Token = tokenHandler.WriteToken(token);  


                     //JWT  

                     return Ok(user);

                }
                else
                {
                    return BadRequest(new { error = "Username or password is invalid" });
                }
                
                
            }
            return BadRequest(new { error = ModelState });
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {


            var reg = new ApplicationUser
            {
                UserName = register.UserName,
                FullName = register.FullName
            };
            
            if (register.UserName == null || register.FullName == null || register.Password == null)
            {
                return BadRequest(new { error = ModelState } );
            }
          

            if (!ModelState.IsValid)
            {
              

                return BadRequest(new { error = ModelState });
            }

            if (_IaccountRepo.checkUsernameExist(register.UserName))
            {
                return BadRequest(new { error = "Username already exist!" });

            }

            /*if (!await _roleManager.RoleExistsAsync("Admin"))
              {
                  //create roles
                  await _roleManager.CreateAsync(new IdentityRole("Admin"));
                  await _roleManager.CreateAsync(new IdentityRole("User"));
              }*/



            var res = await _userManager.CreateAsync(reg, register.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(reg, "User");
                return Ok(reg);
            }


          

            return BadRequest(new { error = ModelState });



        }


        [Route("api/checkusername/{username}")]
        [HttpGet]
        public  bool CheckUserName(string username)
        { 
            if (username == null  )
            {
                return false;
            } 

            if (_IaccountRepo.checkUsernameExist(username))
            {
                return true; 
            } 

            return false;  
        }

    }
}
