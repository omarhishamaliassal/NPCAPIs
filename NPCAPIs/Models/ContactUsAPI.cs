using System.ComponentModel.DataAnnotations;
namespace NPCAPIs.Models
{
    public class ContactUsAPI
    {

        [Key]
        public decimal CUId { get; set; }

        public string? MobileNum { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Location { get; set; }
        

    }
}
