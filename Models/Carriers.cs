using System.ComponentModel.DataAnnotations;

namespace PA_Backend.Models
{
    public class Carrier
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string CarrierShortName { get; set; }
        public string CarrierContactName { get; set; }
        public string CarrierContactEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string CarrierContactPhone { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string CarrierProviderPhone { get; set; }
        [StringLength (256)]
        public string CarrierNotes { get; set; }
        public string CarrierClass { get; set; }
        //(MD = Medicaid, CO=Commercial, etc.)
        public bool CarrierPARequired { get; set; }
    }
}
