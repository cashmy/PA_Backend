using System.ComponentModel.DataAnnotations;

namespace PA_Backend.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        [Required]
        public string StatusColor { get; set; }
        [Required]
        public bool DisplayOnSummary { get; set; }
    }
}
