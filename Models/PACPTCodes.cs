using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Backend.Models
{
    public class PACPTCode
    {
        [Key, Column(Order = 1)]
        [ForeignKey("PriorAuth")]
        public int PARecordId { get; set; }
        public PriorAuth PriorAuth { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("CPTCode")]
        public int PACPTId { get; set; }
        public CPTCode CPTCode { get; set; }
    }
}
