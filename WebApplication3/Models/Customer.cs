using Microsoft.Extensions.Hosting;

namespace ZorginzichtBackend.Models
{
    public class Customer
    {
        public int id { get; set; }

        public int? customer_number { get; set; }

        public string name { get; set; } = "";

        public string? address { get; set; } = "";

        public string? postal_code { get; set; } = "";

        public string? city { get; set; } = "";

        public string? email { get; set; } = "";

        public string password { get; set; } = "";

        public List<Policy>? policies { get; set; }
        public List<Invoice>? invoices { get; set; }
    }
}
