using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Services
{
    public interface IContainerService
    {
        Task<IEnumerable<Container>> GetAll(int userId);
        Task<Container> GetContainerById(int userId, int id);
        Container Create(Container container);
        void Update(Container container);
        void Delete(Container container);
        bool Save();
    }
}
