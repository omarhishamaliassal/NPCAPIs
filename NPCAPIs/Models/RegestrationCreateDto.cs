namespace NPCAPIs.Models
{
    public class RegestrationCreateDto
    {
        public string RegName { get; set; }
        public string? MobileNum { get; set; }
        public string? EMail { get; set; }
        public decimal QualificationId { get; set; }  // FK
        public string CurrentJob { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
