using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZorginzichtBackend.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyByCustomerIdController : ControllerBase
    {
        private readonly BloggingContext _context;

        public PolicyByCustomerIdController(BloggingContext context)
        {
            _context = context;
        }

        
        // GET: api/Policies1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicyByCustomerId(int id)
        {
          if (_context.policies == null)
          {
              return NotFound();
          }
           
            var policy = await _context.policies.Where(policies => policies.CustomerId == id).Include(x => x.additional_insurances).FirstOrDefaultAsync();

            if (policy == null)
            {
                return NotFound("This customer has no linked policy or customer does not excist.");
            }

            return policy;
        }

        private bool PolicyExists(int id)
        {
            return (_context.policies?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
