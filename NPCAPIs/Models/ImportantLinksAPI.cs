using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class ImportantLinksAPI
    {

        [Key]
        public decimal LinkId { get; set; }

        public string? LinkName { get; set; }
        public string? LinkURL { get; set; }

        public string? LinkImage { get; set; }
        public decimal? LinkOrder { get; set; }
        public int? IsActive { get; set; }

    }
}

