namespace ZorginzichtBackend.Models
{
    public class AdditonalInsurrance
    {
        public int id { get; set; }
        public string name { get; set; }
        public int max_coverage { get; set; }
        public int percentage_coverage { get; set; }
        public ICollection<Policy> policies { get; set; }

    
        public InsuranceType InsuranceType { get; set; }
        public int InsuranceTypeId { get; set; }

    }   
}
