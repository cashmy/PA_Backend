using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA_Backend.Models
{
    public class PriorAuth
    {
        public int Id { get; set; }

        [ForeignKey("Patient")]
        public int PAPatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Carrier")]
        public int PACarrierId { get; set; }
        public Carrier Carrier { get; set; }

        public string PACarrierPosition { get; set; }

        [ForeignKey("Status")]
        public int PAStatus { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Treatment")]
        public string PATreatmentCode { get; set; }
        public Treatment Treatment { get; set; }

        [ForeignKey("PlaceOfService")]
        public string PAServiceCode { get; set; }
        public PlaceOfService PlaceOfService { get; set; }

        [ForeignKey("Provider")]
        public int PAProviderId { get; set; }
        public Provider Provider { get; set; }

        [ForeignKey("User")]
        public string PAAssignedStaff { get; set; }
        public User StaffMember { get; set; }

        [ForeignKey("Clinic")]
        public int? PAClinicId { get; set; }
        public Clinic Clinic { get; set; }

        [Required]
        public DateTime PARequestDate { get; set; }

        public DateTime? PALastEvalDate { get; set; }
        public DateTime? PALastPOCDate { get; set; }
        public string PAVisitFrequency { get; set; }
        public int PARqstNmbrVisits { get; set; }
        public DateTime? PAStartDate { get; set; }
        public DateTime? PAExpireDate { get; set; }
        public string PAAuthId { get; set; }
        public bool PAArchived { get; set; }
        public bool PAExpireWarnNotification { get; set; }
        public bool PAExpiredNotification { get; set; }
    }
}
