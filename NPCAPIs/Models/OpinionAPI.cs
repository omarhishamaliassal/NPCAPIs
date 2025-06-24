using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPCAPIs.Models
{
    //[Table("Opinion")]
    public class OpinionAPI
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal OpinionId { get; set; }

        public string Name { get; set; }
        public string? Email { get; set; }
        public string MobileNum { get; set; }
        public string OpinionText { get; set; }
        

    }

}
