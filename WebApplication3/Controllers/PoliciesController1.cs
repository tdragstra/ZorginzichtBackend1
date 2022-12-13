using Microsoft.AspNetCore.Mvc;
using WebApplication3.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class PoliciesController1 : ControllerBase
    {
        private readonly IPolicyRepo policyRepo;
        public PoliciesController1(IPolicyRepo repo)
        {
            policyRepo = repo;
        }

        [HttpGet("GetPolicies")]
            public async Task<IActionResult> GetPolicies()
        {
            try
            {
                var policies = await policyRepo.GetAllPolicies();
                return Ok(policies);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }

    }
}
