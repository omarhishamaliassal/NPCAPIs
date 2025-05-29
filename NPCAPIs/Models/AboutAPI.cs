using System.ComponentModel.DataAnnotations;

namespace NPCAPIs.Models
{
    public class AboutAPI
    {
        [Key]
        public decimal AboutId { get; set; }

        public string AboutText { get; set; }
        public string AboutImg { get; set; }

        public string ChairmanWord { get; set; }
        public string ChairmanImg { get; set; }

        public string MinisterWord { get; set; }
        public string MinisterImg { get; set; }
        public string StructureText { get; set; }
        public string StructureImg { get; set; }

        public string Pillar1 { get; set; }
        public string Pillar1Text { get; set; }
        public string Pillar2 { get; set; }
        public string Pillar2Text { get; set; }
        public string Pillar3 { get; set; }
        public string Pillar3Text { get; set; }

        public string Mechanisms { get; set; }
    }
}
