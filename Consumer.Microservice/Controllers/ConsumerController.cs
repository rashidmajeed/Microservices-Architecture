using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Microservice.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consumer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        private IApplicationDbContext _context;
        public ConsumerController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Consumer consumer)
        {
            _context.Consumers.Add(consumer);
            await _context.SaveChanges();
            return Ok(consumer.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consumers = await _context.Consumers.ToListAsync();
            if (consumers == null) return NotFound();
            return Ok(consumers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consumer = await _context.Consumers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (consumer == null) return NotFound();
            return Ok(consumer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consumer = await _context.Consumers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (consumer == null) return NotFound();
            _context.Consumers.Remove(consumer);
            await _context.SaveChanges();
            return Ok(consumer.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Consumer consumerData)
        {
            var consumer = _context.Consumers.Where(a => a.Id == id).FirstOrDefault();

            if (consumer == null) return NotFound();
            else
            {
                consumer.Title = consumerData.Title;
                consumer.Name = consumerData.Name;
                consumer.Contact = consumerData.Contact;
                consumer.Address = consumerData.Address;
                await _context.SaveChanges();
                return Ok(consumer.Id);
            }
        }
    }
}