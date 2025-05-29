using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class InfographAPI
    {

        [Key]
        public decimal InfoId { get; set; }

        public string? InfoTitle { get; set; }
        public string? InfoDesc { get; set; }
        public string? InfoPhoto { get; set; }
        public DateTime? PublicationDate { get; set; }
        public decimal? OrderView { get; set; }
        public string? URLink { get; set; }

        public int? OnMainPage { get; set; }

        public int? IsActive { get; set; }

    }
}

