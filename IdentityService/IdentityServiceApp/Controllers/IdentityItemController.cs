using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServiceApp.DTOs;
using IdentityServiceApp.Models;
using IdentityServiceApp.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityItemController : ControllerBase
    {
        private readonly ILogger<IdentityItemController> _logger;
        private readonly IIdentityRepository _repository;
        private readonly IMapper _mapper;

        [ActivatorUtilitiesConstructor]
        public IdentityItemController(IIdentityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IdentityItemController(ILogger<IdentityItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<IdentityItemDto>> GetItemsAsync()
        {
            var items = (await _repository.GetItemsAsync())
                .Select(item => _mapper.Map<IdentityItemDto>(item));
            
            return items;
        }

        //GET/Item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityItemDto>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);

            if (item is null) return NotFound();

            return Ok(_mapper.Map<IdentityItemDto>(item));
        }

        // POST/items
        [HttpPost]
        public async Task<ActionResult<IdentityItemDto>> CreateIdentityAsync(CreateIdentityItemDto createdItemDto)
        {
            
            IdentityItem item = _mapper.Map<IdentityItem>(createdItemDto);

            await _repository.CreateItemAsync(item);

            string actionName = nameof(GetItemAsync);

            return CreatedAtAction(actionName, new {id = item.Id}, _mapper.Map<IdentityItemDto>(item));
        }

        // PUT/items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIdentityAsync(Guid id, UpdateIdentityDto updatedItemDto)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();

            var updatedItem = existingItem with
            {
                FirstName = updatedItemDto.FirstName,
                LastName = updatedItemDto.LastName,
                Password = updatedItemDto.Password,
                Address = updatedItemDto.Address,
                Contact = updatedItemDto.Contact,
                CreatedDate = updatedItemDto.CreatedDate,
            };

            await _repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }

        //DELETE/items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();

            await _repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}