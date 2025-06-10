using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class CommonQuestionAPI
    {

        [Key]
        public decimal QId { get; set; }

        public string? Quest { get; set; }
        public string? Answer { get; set; }
 

        public int? IsActive { get; set; }

    }
}
