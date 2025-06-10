using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class LkpMashoraTypeAPI
    {

        [Key]
        public decimal MashoraId { get; set; }

        public string? MashoraDesc { get; set; }
      
  

        public int? IsActive { get; set; }

    }
}
