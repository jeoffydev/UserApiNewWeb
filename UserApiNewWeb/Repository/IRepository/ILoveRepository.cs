using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;

namespace UserApiNewWeb.Repository.IRepository
{
    public interface ILoveRepository
    {
        bool CreateLove(string userid, int storyid);
        int DeleteLove(string userid, int storyid);

    }
}
