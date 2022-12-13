using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZorginzichtBackend.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceTypesController : ControllerBase
    {
        private readonly BloggingContext _context;

        public InsuranceTypesController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/InsuranceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsuranceType>>> Getinsurance_types()
        {
          if (_context.insurance_types == null)
          {
              return NotFound();
          }
            return await _context.insurance_types.ToListAsync();
        }

        // GET: api/InsuranceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceType>> GetInsuranceType(int id)
        {
          if (_context.insurance_types == null)
          {
              return NotFound();
          }
            var insuranceType = await _context.insurance_types.FindAsync(id);

            if (insuranceType == null)
            {
                return NotFound();
            }

            return insuranceType;
        }

        // PUT: api/InsuranceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsuranceType(int id, InsuranceType insuranceType)
        {
            if (id != insuranceType.id)
            {
                return BadRequest();
            }

            _context.Entry(insuranceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InsuranceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InsuranceType>> PostInsuranceType(InsuranceType insuranceType)
        {
          if (_context.insurance_types == null)
          {
              return Problem("Entity set 'BloggingContext.insurance_types'  is null.");
          }
            _context.insurance_types.Add(insuranceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsuranceType", new { id = insuranceType.id }, insuranceType);
        }

        // DELETE: api/InsuranceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsuranceType(int id)
        {
            if (_context.insurance_types == null)
            {
                return NotFound();
            }
            var insuranceType = await _context.insurance_types.FindAsync(id);
            if (insuranceType == null)
            {
                return NotFound();
            }

            _context.insurance_types.Remove(insuranceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsuranceTypeExists(int id)
        {
            return (_context.insurance_types?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
