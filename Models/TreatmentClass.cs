using System.ComponentModel.DataAnnotations;

namespace PA_Backend.Models
{
    public class Treatment
    {
        [Key]
        public string TreatmentCode { get; set; }
        public string TreatmentName { get; set; }
    }
}
