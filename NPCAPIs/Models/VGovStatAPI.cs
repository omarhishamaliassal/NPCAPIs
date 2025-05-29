using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class VGovStatAPI
    {
        [Key]
        public decimal GovId { get; set; }
        public decimal RoomsNumUnits { get; set; }
        public decimal RoomsNumHospitals { get; set; }
        public decimal WorkersNum { get; set; }
        public string GovName { get; set; }
    }
}
