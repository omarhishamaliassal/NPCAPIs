using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class VServicesAPI
    {
        [Key]
        public decimal MashoraId { get; set; }
        public string? MashoraDesc { get; set; }
        public string? MashoraFile { get; set; }
        public string? ServDesc { get; set; }
      


    }
}
