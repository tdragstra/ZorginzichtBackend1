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
    public class InvoicesController : ControllerBase
    {
        private readonly BloggingContext _context;

        public InvoicesController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> Getinvoices()
        {
          if (_context.invoices == null)
          {
              return NotFound();
          }
            return await _context.invoices.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
          if (_context.invoices == null)
          {
              return NotFound();
          }
            var invoice = await _context.invoices.FindAsync(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
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

        // POST: api/Invoices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
          if (_context.invoices == null)
          {
              return Problem("Entity set 'BloggingContext.invoices'  is null.");
          }
            _context.invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = invoice.id }, invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            if (_context.invoices == null)
            {
                return NotFound();
            }
            var invoice = await _context.invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return (_context.invoices?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
