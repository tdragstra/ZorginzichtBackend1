namespace ZorginzichtBackend.Models
{
    public class Invoice
    {
        public int id { get; set; }

        public double costs { get; set; }

        public DateTime? created { get; set; } = DateTime.Now;



        public int InsuranceTypeId { get; set; }
        public InsuranceType InsuranceType { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
    }
}
