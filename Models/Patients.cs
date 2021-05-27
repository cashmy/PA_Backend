using System;
using System.ComponentModel.DataAnnotations;

namespace PA_Backend.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientDOB { get; set; }
        public bool PatientHaveIEP { get; set; }
        public bool PatientInABA { get; set; }
        public string PatientClass { get; set; }
        [StringLength(256)]
        public string PatientNotes { get; set; }
        public bool PatientInactive { get; set; }
    }
}
