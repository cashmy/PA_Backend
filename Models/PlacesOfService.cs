using System.ComponentModel.DataAnnotations;


namespace PA_Backend.Models
{
    public class PlaceOfService
    {
        [Key]
        public string PlaceOfServiceCode { get; set; }
        public string PlaceOfServiceDesc { get; set; }
    }
}
