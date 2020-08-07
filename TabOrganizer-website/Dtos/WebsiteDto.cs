using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TabOrganizer_website.Dtos
{
    public class WebsiteDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        public string Comment { get; set; }
    }
}
