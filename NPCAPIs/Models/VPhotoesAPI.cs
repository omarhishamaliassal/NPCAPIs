using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class VPhotoesAPI
    {
        [Key]
        public decimal AlbumId { get; set; }
        public decimal PhotoId { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime? PublishDate { get; set; }

        public string? PhotoTitle { get; set; }
        public string? Photo { get; set; }

        public decimal?OrderView { get; set; }

        public int? IsActive { get; set; }

    }
}
