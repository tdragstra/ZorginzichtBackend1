using Microsoft.Extensions.Hosting;

namespace ZorginzichtBackend.Models
{
    public class InsuranceType
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? type_name { get; set; }
        public List<Invoice> invoices { get; set; }
        public List<AdditonalInsurrance> additonal_insurrances { get; set; }
    }
}
