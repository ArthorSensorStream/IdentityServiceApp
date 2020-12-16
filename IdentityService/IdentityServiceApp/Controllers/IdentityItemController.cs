using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<IdentityItemDto> Get()
        {
            return _repository.GetItems().Select(item => item.AsDto());
        }

        //GET/Item/{id}
        [HttpGet("{id}")]
        public ActionResult<IdentityItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if (item is null) return NotFound();

            return Ok(item.AsDto());
        }

        // POST/items
        [HttpPost]
        public ActionResult<IdentityItemDto> CreateIdentity(CreateIdentityItemDto itemDto)
        {
            var item = new IdentityItem()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                CreatedDate = DateTimeOffset.UtcNow
            };

            _repository.CreateItem(item);
            
            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        // PUT/items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateIdentity(Guid id, UpdateIdentityDto itemDto)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem is null) return NotFound();

            var updatedItem = existingItem with
            {
                Name = itemDto.Name
            };
            
            _repository.UpdateItem(updatedItem);
            return NoContent();
        }
        
        //DELETE/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);
            if (existingItem is null) return NotFound();
            
            _repository.DeleteItem(id);
            return NoContent();
        }
    }
}
