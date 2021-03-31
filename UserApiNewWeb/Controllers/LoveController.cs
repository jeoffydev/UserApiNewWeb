using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Repository.IRepository;

namespace UserApiNewWeb.Controllers
{
    [Authorize]
    public class LoveController : Controller
    {
        private ILoveRepository _loveRepo;
        private IMapper _imapper;

        public LoveController(ILoveRepository loverepo, IMapper mapper)
        {
            _loveRepo = loverepo;
            _imapper = mapper;

        }

        [HttpGet]
        [Route("api/love/{userid}/{storyid}")]
        public IActionResult CreateLove(string userid, int storyid)
        {
            var added = _loveRepo.CreateLove(userid, storyid);
            if(added == true)
            {
                return Ok(new { message = "success" });
            }
            return Ok(new { message = "failed" });

        }

        [HttpGet]
        [Route("api/lovedelete/{userid}/{storyid}")]
        public IActionResult DeleteLove(string userid, int storyid)
        {
            var del = _loveRepo.DeleteLove(userid, storyid);
            if (del == 1)
            {
                return Ok(new { message = "success" });
            }
            return Ok(new { message = "failed" });

        }
    }
}
