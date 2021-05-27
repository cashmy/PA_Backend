using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PA_Backend.Models
{
    public class PADiagCode
    {
        [Key, Column(Order = 1)]
        [ForeignKey("PriorAuth")]
        public int PARecordId { get; set; }
        public PriorAuth PriorAuth { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("DiagnosisCode")]
        public string PADiagId { get; set; }
        public DiagnosisCode DiagnosisCode { get; set; }
    }
}
