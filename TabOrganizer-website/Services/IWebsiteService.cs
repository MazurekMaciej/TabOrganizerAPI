using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Services
{
    public interface IWebsiteService
    {
        IEnumerable<Website> GetAllWebsites(int containerId);
        Website GetWebsiteById(int containerId, int id);
        Website Create(Website website);
        void Update(Website website);
        void Delete(Website website);
        bool Save();
    }
}
