using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Interfaces;
using GestContact.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactServices<Contact> _contactServices;

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactServices<Contact> contactServices)
        {
            _logger = logger;
            _contactServices = contactServices;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactServices.Get();
        }

        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactServices.Get(id);
        }

        [HttpPost]
        public Contact Post([FromBody]Contact entity)
        {
            return _contactServices.Insert(entity);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Contact entity)
        {
            _contactServices.Update(id, entity);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _contactServices.Delete(id);
        }
    }
}
