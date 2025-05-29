using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class InitiativeNumbersAPI
    {

        [Key]
        public decimal InitId { get; set; }

        public string? IndTitle { get; set; }
        public decimal? IndNumber { get; set; }
        public string? IndUnit{ get; set; }
        public int? OnMainPage { get; set; }

        public int? IsActive { get; set; }

    }
}
