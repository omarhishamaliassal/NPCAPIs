using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class VActiveEmpAPI
    {
        [Key]
        public decimal GovId { get; set; }

        public string GovName { get; set; }
        public string EmpName { get; set; }
        public string EmpJob { get; set; }

        public string EmpFacilityUnit { get; set; }
        public DateTime HonorDate { get; set; }
        public string EmpImage { get; set; }
        public int OnMainPage { get; set; }
        
    }
}
