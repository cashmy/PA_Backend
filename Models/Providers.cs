using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA_Backend.Models
{
    public class Provider
    {
        public int ProviderId { get; set; }

        // Provider's UserID is an optional field
        // Manually validated against the role of "Provider"
        public string ProviderUserId { get; set; }

        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        
        // Default to user email unless "ProviderUserId is blank than this field should be required 
        public string ProviderEmail { get; set; }
        public string ProviderPhone { get; set; }
        public bool ProviderRcvEmails { get; set; }
        public bool ProviderRcvNotifications { get; set; }

        public string ProviderNPI { get; set; }
        public string ProviderTaxonomy { get; set; }

        //Validated against the role of "staff"
        [ForeignKey("User")]
        public string AssignedStaffUserId { get; set; }
        public User User { get; set; }

        [StringLength(256)]
        public string ProviderNotes { get; set; }
        public bool ProviderInactive { get; set; }
    }
}