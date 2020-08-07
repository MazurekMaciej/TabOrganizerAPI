using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Data;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly DataContext _context;

        public WebsiteService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Website> GetAllWebsites(int containerId)
        {
            return _context.Websites.Where(w => w.ContainerId == containerId).ToList();
        }

        public Website GetWebsiteById(int containerId, int id)
        {
            return _context.Websites.Where(w => w.ContainerId == containerId && w.Id == id).SingleOrDefault();
        }

        public Website Create(Website website)
        {
            _context.Websites.Add(website);

            return website;
        }

        public void Update(Website website)
        {
            //automapper are you gonna handle it?
        }

        public void Delete(Website website)
        {
            _context.Websites.Remove(website);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
