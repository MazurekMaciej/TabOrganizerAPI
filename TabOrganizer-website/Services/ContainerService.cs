using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using TabOrganizer_website.Data;
using TabOrganizer_website.Helpers.Exceptions;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Services
{
    public class ContainerService : IContainerService
    {
        private readonly DataContext _context;

        public ContainerService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Container>> GetAll(int userId)
        {
            return await _context.Containers.Include(c=>c.Websites).Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<Container> GetContainerById(int userId, int id)
        {
            return await _context.Containers.SingleOrDefaultAsync(c => c.UserId == userId && c.Id == id);
        }

        public Container Create(Container container)
        {
            _context.Containers.Add(container);

            return container;
        }

        public void Update(Container container)
        {
            //automapper gonna do this
        }

        public void Delete(Container container)
        {
            _context.Containers.Remove(container);
        }


        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
