using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPCAPIs.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal TeamMemberId { get; set; }   // PK
        public string MemberName { get; set; }
        public string? MobileNum { get; set; }
        public string? EMail { get; set; }
        public decimal QualificationId { get; set; }  // FK
        public string CurrentJob { get; set; }
        public DateTime? EntryDate { get; set; }          // FK

        // Navigation Property
        public LkpQualification Qualification { get; set; }
    }
}
