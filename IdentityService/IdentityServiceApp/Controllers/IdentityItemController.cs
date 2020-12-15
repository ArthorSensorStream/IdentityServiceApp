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
    }
}
