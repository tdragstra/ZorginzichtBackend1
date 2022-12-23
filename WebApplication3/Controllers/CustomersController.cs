using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZorginzichtBackend.Models;
using WebApplication3.Helpers; 

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BloggingContext _context;

        public CustomersController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<List<CustomerDTO>> GetCustomers()
        {
            List<CustomerDTO> customerlist = new List<CustomerDTO>();
            var customers = await _context.customers.Include(x => x.invoices).ToListAsync();
            foreach (Customer customer in customers) {
                CustomerDTO customerDTO = new CustomerDTO(customer);
                customerlist.Add(customerDTO);
            }
                return customerlist;
        
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
          if (_context.customers == null)
          {
              return NotFound();
          }
            var customer = await _context.customers.Include(customer => customer.policies).ThenInclude(policies => policies.additional_insurances).ThenInclude(z => z.InsuranceType).FirstOrDefaultAsync(i => i.id == id);

          /*  // extra includes gewoon om te testen, niet nodig.
            await _context.policies
                .Include(x => x.Customer)
                .Include(z => z.Invoices).IgnoreAutoIncludes()

                .ToListAsync();*/
            if (customer == null )
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            // Remove updated password
            if (id != customer.id)
            {
                return BadRequest();
            }

            customer.password = LoginHelper.HashPassword(customer.password);

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            if (_context.customers == null)
            {
                return Problem("Entity set 'BloggingContext.customers'  is null.");
            }

            // Assign hashed password to customer
            customer.password = LoginHelper.HashPassword(customer.password);

            // Add default policy to customer
            customer.policies = new List<Policy>
            {
                new Policy {
                    policy_nr = 1,
                    policyname = "Achmea Basis",
                    insurance = "Zorgverzekering",
                    costs = 120.50f, active = true,
                    additional_insurances = _context.additional_insurances.Where(insurance => insurance.id == 1).ToList()
                }
            };

            // Add new customer to context
            _context.customers.Add(customer);

            // Save changes in context
            await _context.SaveChangesAsync();

            Customer newCustomer = _context.customers.OrderBy(customer => customer.id).Last();

            newCustomer.customer_number = 37000 + newCustomer.id;

            _context.Update(newCustomer);

            await _context.SaveChangesAsync();

            // Return the customer
            return CreatedAtAction("GetCustomer", new { id = customer.id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.customers == null)
            {
                return NotFound();
            }
            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.customers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
