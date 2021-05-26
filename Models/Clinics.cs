using System.ComponentModel.DataAnnotations;

namespace PA_Backend.Models
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public string ClinicAddress1 { get; set; }
        public string ClinicAddress2 { get; set; }
        public string ClinicCity { get; set; }
        public string ClinicState { get; set; }
        public string ClinicZip { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string ClinicPhone { get; set; }
        public long ClinicNPI { get; set; }
        public bool ClinicIsAGroup { get; set; }

    }
}
