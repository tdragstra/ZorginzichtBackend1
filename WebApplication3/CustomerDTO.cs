using ZorginzichtBackend.Models;

namespace WebApplication3
{
    public class CustomerDTO

    {
        public int id { get; set; }
        public int customer_number { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public List<Policy> policies { get; set; }
        public List<Invoice> invoices { get; set; }
        public CustomerDTO(Customer customer) {
            this.name = customer.name;
            this.email = customer.email;
            this.policies = customer.policies;
            this.invoices = customer.invoices;
            this.id= customer.id;
            this.customer_number= customer.customer_number;
        }
    }
}
