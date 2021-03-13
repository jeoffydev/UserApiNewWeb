using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApiNewWeb.Models;

namespace UserApiNewWeb.Repository.IRepository
{
    public interface IAccountRepository
    {
        ApplicationUser Login(ApplicationUser login);
        bool checkUsernameExist(string username);
    }
}
