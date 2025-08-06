using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPCAPIs.Models
{
    public class Regestration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal RegesterId { get; set; }   // PK
        public string RegName { get; set; }
        public string? MobileNum { get; set; }
        public string? EMail { get; set; }
        public decimal QualificationId { get; set; }  // FK
        public string CurrentJob { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? EntryDate { get; set; }          // FK

        // Navigation Property
        public LkpQualification Qualification { get; set; }
    }
}
