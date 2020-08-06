using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Dtos
{
    public class ContainerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
