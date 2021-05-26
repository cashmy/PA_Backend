using System.ComponentModel.DataAnnotations;


namespace PA_Backend.Models
{
    public class DiagnosisCode
    {
        [Key]
        public string DiagCode { get; set; }
        public string DiagDescription { get; set; }
    }
}
