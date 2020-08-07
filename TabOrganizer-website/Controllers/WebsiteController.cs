using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabOrganizer_website.Dtos;
using TabOrganizer_website.Helpers.Exceptions;
using TabOrganizer_website.Models;
using TabOrganizer_website.Services;

namespace TabOrganizer_website.Controllers
{
    [Authorize]
    [Route("api/websites")]
    [ApiController]
    public class WebsiteController : ControllerBase
    {
        private readonly IWebsiteService _websiteService;
        private readonly IContainerService _containerService;
        private readonly IMapper _mapper;

        public WebsiteController(IWebsiteService websiteService, IContainerService containerService, IMapper mapper)
        {
            _websiteService = websiteService;
            _containerService = containerService;
            _mapper = mapper;
        }

        //GET api/websites/{containerId}
        [HttpGet("{containerId}", Name = nameof(GetAllWebsites))]
        public async Task<IActionResult> GetAllWebsites(int containerId)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, containerId);

            if (container == null)
                return NotFound("Container not found");

            var webistes = _websiteService.GetAllWebsites(containerId);

            if (webistes != null)
                return Ok(_mapper.Map<IEnumerable<WebsiteReadDto>>(webistes));

            return NotFound("Webistes not found");
        }

        //GET api/websites/{containerId}/{websiteId}
        [HttpGet("{containerId}/{id}", Name = nameof(GetWebsiteById))]
        public async Task<IActionResult> GetWebsiteById(int containerId, int id)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, containerId);

            if (container == null)
                return NotFound("Container not found");

            var website = _websiteService.GetWebsiteById(containerId, id);

            if (website != null)
                return Ok(_mapper.Map<WebsiteReadDto>(website));

            return NotFound("Website not found");
        }

        //POST api/websites/{containerId}
        [HttpPost("{containerId}", Name = nameof(CreateWebsite))]
        public async Task<IActionResult> CreateWebsite(int containerId, WebsiteDto websiteCreateDto)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, containerId);

            if (container == null)
                return NotFound("Container not found");

            var website = _mapper.Map<Website>(websiteCreateDto);

            website.DateAdded = DateTime.Now;
            website.ContainerId = containerId;

            var websiteCreated = _websiteService.Create(website);

            if (_containerService.Save())
            {
                var websiteToReturn = _mapper.Map<WebsiteReadDto>(websiteCreated);
                return CreatedAtRoute(nameof(GetWebsiteById), new { containerId, websiteCreated.Id }, websiteToReturn);
            }

            return BadRequest("");
        }

        //PUT api/websites/{containerId}/{id}
        [HttpPut("{containerId}/{id}", Name = nameof(UpdateWebsite))]
        public async Task<IActionResult> UpdateWebsite(int containerId, int id, WebsiteDto websiteDto)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, containerId);

            if (container == null)
                return NotFound("");

            var website = _websiteService.GetWebsiteById(containerId, id);

            if (website == null)
            {
                return NotFound();
            }
            _mapper.Map(websiteDto, website); //update

            _websiteService.Update(website); //doing nothing

            if (!_containerService.Save())
            {
                throw new AppException("Updating a website failed on save.");
            }

            return Ok(_mapper.Map<WebsiteReadDto>(website));
        }

        //DELETE api/websites/{containerId}/{id}
        [HttpDelete("{containerId}/{id}", Name = nameof(DeleteWebsite))]
        public async Task<IActionResult> DeleteWebsite(int containerId, int id)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, containerId);

            if (container == null)
                return NotFound("");

            var website = _websiteService.GetWebsiteById(containerId, id);

            if (website == null)
            {
                return NotFound();
            }

            _websiteService.Delete(website);

            if (!_containerService.Save())
                throw new AppException("Deleteing a website failed on save.");

            return NoContent();
        }
    }
}
