using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Helpers;
using ZorginzichtBackend.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly BloggingContext _context;

        public LoginController (BloggingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Login(string email, string password)
        {
            // Get list of customers from the context
            List<Customer> customers = await _context.customers.ToListAsync();

            // Get customer with matching email and password
            Customer? match = customers.Where(customer => customer.email == email && LoginHelper.MatchPassword(password, customer.password)).FirstOrDefault();

            if (match == null) return -1;

            return match.id;
        }

    }
}
    