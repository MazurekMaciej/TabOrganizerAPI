using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        User GetById(int id);
    }
}
