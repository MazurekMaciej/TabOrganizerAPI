using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Dtos
{
    public class ContainerCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
