using ZorginzichtBackend.Models;

namespace WebApplication3.Interface
{
    public interface IPolicyRepo
    {
        public Task<List<Policy>> GetAllPolicies();
    }
}
