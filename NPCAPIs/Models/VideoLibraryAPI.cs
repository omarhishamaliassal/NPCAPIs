using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class VideoLibraryAPI
    {

        [Key]
        public decimal VedioId { get; set; }

        public string? VedioTitle { get; set; }
    
        public DateTime? PublishDate { get; set; }

        public string? VCoverPhoto { get; set; }
        public string? VedioURL { get; set; }

        public int? OnMainPage { get; set; }

        public int? IsActive { get; set; }

    }
}

