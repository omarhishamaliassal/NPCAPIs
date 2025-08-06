using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NPCAPIs.Models
{
    [Table("LkpQualification")]
    public class LkpQualification
    {
        [Key]
        public decimal QualificationId { get; set; }  // PK
        public string QualificationDesc { get; set; }

        // Navigation Property
        [JsonIgnore]
        public ICollection<TeamMember> TeamMembers { get; set; }
        [JsonIgnore]
        public ICollection<Regestration> Regestrations { get; set; }
    }
}
