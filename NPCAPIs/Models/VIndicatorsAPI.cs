using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class VIndicatorsAPI
    {
         
        [Key]
        public decimal IndId { get; set; }
        public decimal GovId { get; set; }
        public string IndName { get; set; }
        public string GovName { get; set; }
        public string MonthDesc { get; set; }
        public string MashoraDesc { get; set; }
        public DateTime? Date { get; set; }

        public decimal? MonthId { get; set; }
        public decimal? IndYear { get; set; }
        public decimal? IndValue { get; set; }

      
        

    }
}
