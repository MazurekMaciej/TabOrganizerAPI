using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabOrganizer_website.Dtos;
using TabOrganizer_website.Helpers.Exceptions;
using TabOrganizer_website.Models;
using TabOrganizer_website.Services;

namespace TabOrganizer_website.Controllers
{
    [Authorize]
    [Route("api/containers")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IContainerService _containerService;
        private readonly IMapper _mapper;

        public ContainerController(IContainerService containerService, IMapper mapper)
        {
            _containerService = containerService;
            _mapper = mapper;
        }

        // GET: api/containers/
        [HttpGet(Name = nameof(GetAllContainers))]
        public async Task<IActionResult> GetAllContainers()
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var containers = await _containerService.GetAll(currentUserId);

            if (containers != null)
                return Ok(_mapper.Map<IEnumerable<ContainerReadDto>>(containers));

            return NotFound();
        }

        // GET api/containers/id
        [HttpGet("{id}", Name = nameof(GetContainerById))]
        public async Task<IActionResult> GetContainerById(int id)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var container = await _containerService.GetContainerById(currentUserId, id);

            if (container != null)
                return Ok(_mapper.Map<ContainerReadDto>(container));

            return NotFound();
        }

        // POST api/containers
        [HttpPost(Name = nameof(CreateContainer))]
        public IActionResult CreateContainer([FromBody] ContainerCreateDto containerDto)
        {

            int currentUserId = int.Parse(User.Identity.Name);

            var container = _mapper.Map<Container>(containerDto);

            container.UserId = currentUserId;
            container.DateCreation = DateTime.Now;

            var containerCreated = _containerService.Create(container);

            if (_containerService.Save())
            {
                var containerToReturn = _mapper.Map<ContainerReadDto>(containerCreated);
                return CreatedAtRoute(nameof(GetContainerById), new { Id = containerToReturn.Id }, containerToReturn);
            }

            return BadRequest("Container not created");
        }

        // PUT api/containers/5
        [HttpPut("{id}", Name = nameof(UpdateContainer))]
        public async Task<IActionResult> UpdateContainer(int id, [FromBody] ContainerUpdateDto containerDto)
        {
            if (string.IsNullOrEmpty(containerDto.Name))
            {
                return BadRequest("Name cannot be empty");
            }

            int currentUserId = int.Parse(User.Identity.Name);
            var existingContainer = await _containerService.GetContainerById(currentUserId, id);

            if (existingContainer == null)
                return NotFound();

            _mapper.Map(containerDto, existingContainer); //update in itself

            _containerService.Update(existingContainer); //doing nothing

            if (!_containerService.Save())
                throw new AppException("Updating a container failed on save.");

            return Ok(_mapper.Map<ContainerReadDto>(existingContainer));
        }

        // DELETE api/containers/5
        [HttpDelete("{id}", Name = nameof(DeleteContainer))]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var existingContainer = await _containerService.GetContainerById(currentUserId, id);

            if (existingContainer == null)
                return NotFound();

            _containerService.Delete(existingContainer);

            if (!_containerService.Save())
                throw new AppException("Deleting a container failed on save.");

            return NoContent();
        }
    }
}
