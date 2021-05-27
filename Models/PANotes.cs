using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Backend.Models
{
    public class PANote
    {
        [Key, Column(Order = 1)]
        [ForeignKey("PriorAuth")]
        public int PARecordId { get; set; }
        public PriorAuth PriorAuth { get; set; }

        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PANoteId { get; set; }

        [ForeignKey("NoteType")]
        public int PANoteTypeId { get; set; }
        public NoteType NoteType { get; set; }

        [StringLength(256)]
        public string PANoteText { get; set; }

        [ForeignKey("User")]
        public string PANoteUserId { get; set; }
        public User User { get; set; }


    }
}
