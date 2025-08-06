namespace NPCAPIs.Models
{
    public class TeamMemberCreateDto
    {
        public string MemberName { get; set; }
        public string? MobileNum { get; set; }
        public string? EMail { get; set; }
        public int QualificationId { get; set; }  // Must exist in LkpQualification
        public string CurrentJob { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
