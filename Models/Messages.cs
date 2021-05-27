using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Backend.Models
{
    public class Message
    {
        [Key, Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [StringLength(256)]
        public string MessageText { get; set; }
    }
}
