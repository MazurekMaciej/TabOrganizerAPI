using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }

        public int ContainerId { get; set; }
        public Container Container { get; set; }
    }
}
