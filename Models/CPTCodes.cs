using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Backend.Models
{
    public class CPTCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CPTCodeId { get; set; }
        public string CPTDescription { get; set; }
    }
}
