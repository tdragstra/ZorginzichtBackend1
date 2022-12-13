using Microsoft.EntityFrameworkCore;
using WebApplication3.Interface;
using ZorginzichtBackend.Models;


namespace WebApplication3.Repositories
{
    public class PolicyRepository : IPolicyRepo
    {
        private readonly BloggingContext DbContext;
        public PolicyRepository(BloggingContext databaseContext)
        {
            DbContext = databaseContext; 
        }

        async Task<List<Policy>> IPolicyRepo.GetAllPolicies()
        {
            var policies = await DbContext.policies.Include(x => x.Customer).ToListAsync();
            return policies;
        } 
    }
}
