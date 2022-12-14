using System.Configuration;

namespace ZorginzichtBackend.Models
{
    public class AdditonalInsurrance
    {
        public int id { get; set; }
        public string name { get; set; }
        public int max_coverage { get; set; }
        public int costs { get; set; }
        // let op als je deze migratie terugdraaid dat je de seeds uit comment. De many-to-many staat in migration.

        public ICollection<Policy>? policies { get; set; }
    
        public InsuranceType? InsuranceType { get; set; }
        public int InsuranceTypeId { get; set; }

    }   
}
