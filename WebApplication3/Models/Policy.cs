using Microsoft.Identity.Client;
using System.Reflection.Metadata;

namespace ZorginzichtBackend.Models
{
    public class Policy
    {
        public int id { get; set; }

        public int policy_nr { get; set; }

        public string? policyname { get; set; }

        public string? insurance { get; set; }

        public float? costs { get; set; } = 0;

        public bool active { get; set; } = true;

        public ICollection<AdditonalInsurrance>? additional_insurances { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<Invoice>? Invoices { get; set; }
        

    }
}
