using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class AwarenessMsgAPI
    {

        [Key]
        public decimal MsgId { get; set; }

        
        public string? MsgText { get; set; }

        public decimal? OrderView { get; set; }
        public int? IsActive { get; set; }

    }
}
