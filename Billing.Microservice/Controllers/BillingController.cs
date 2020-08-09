using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private IApplicationDbContext _context;
        public BillingController(IApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Billing billing)
        {
            _context.Billings.Add(billing);
            await _context.SaveChanges();
            return Ok(billing.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var billings = await _context.Billings.ToListAsync();
            if (billings == null) return NotFound();
            return Ok(billings);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var billing = await _context.Billings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (billing == null) return NotFound();
            return Ok(billing);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var billing = await _context.Billings.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (billing == null) return NotFound();
            _context.Billings.Remove(billing);
            await _context.SaveChanges();
            return Ok(billing.Id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Billings billingData)
        {
            var billing = _context.Billings.Where(a => a.Id == id).FirstOrDefault();
            if (billing == null) return NotFound();
            else
            {
                billing.Name = productData.Name;
                billing.Rate = productData.Rate;
                await _context.SaveChanges();
                return Ok(product.Id);
            }
        }
    }
}