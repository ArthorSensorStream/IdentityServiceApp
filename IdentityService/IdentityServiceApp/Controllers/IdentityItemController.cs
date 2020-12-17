using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [ActivatorUtilitiesConstructor]
        public IdentityItemController(IIdentityRepository repository)
        {
            _repository = repository;
        }

        public IdentityItemController(ILogger<IdentityItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<IdentityItemDto>> GetItemsAsync()
        {
            var items = (await _repository.GetItemsAsync())
                .Select(item => item.AsDto());
            return items;
        }

        //GET/Item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityItemDto>> GetItemAsync(Guid id)
        {
            var item = await _repository.GetItemAsync(id);

            if (item is null) return NotFound();

            return Ok(item.AsDto());
        }

        // POST/items
        [HttpPost]
        public async Task<ActionResult<IdentityItemDto>> CreateIdentityAsync(CreateIdentityItemDto itemDto)
        {
            var item = new IdentityItem()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await _repository.CreateItemAsync(item);

            string actionName = nameof(GetItemAsync);

            return CreatedAtAction(actionName, new {id = item.Id}, item.AsDto());
        }

        // PUT/items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIdentityAsync(Guid id, UpdateIdentityDto itemDto)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null) return NotFound();

            var updatedItem = existingItem with
            {
                Name = itemDto.Name
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