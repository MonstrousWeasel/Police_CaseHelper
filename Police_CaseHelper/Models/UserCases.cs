using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Police_CaseHelper.Models
{
    public class UserCases
    {
        //Cases ID
        [Key]
        public int CaseID { get; set; }

        //Victim's Name
        [DisplayName("Victim Name")]
        [Required]
        public string? VictimName { get; set; }

        //Offender's Name
        [DisplayName("Offenders Name")]
        [Required]
        public string? OffenderName { get; set; }

        //What are the charges
        public string? Charges { get; set; }

        //Offender's plea
        [DisplayName("Offenders Plea")]
        public string? OffenderPlea { get; set; }

        //Is the offender in custody? Yes, No
        [DisplayName("Offender in Custody")]
        public bool OffenderInCustody { get; set; }

        //If offender in custody, what is the release date
        [DisplayName("Offender Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? OffenderReleaseDate { get; set; }

        //When is the next court date
        [DisplayName("Next Court Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? CourtDates { get; set; }

        //Where is the court locatin
        [DisplayName("Court Location")]
        public string? CourtLocation { get; set; }

        //What is the next court date about, and results if applicable/available
        [DisplayName("Case Details")]
        public string? Details { get; set; }

        //Has the offender got bail? Yes, No
        public bool Bail { get; set; }

        //If the offender has got bail, what are the conditions?
        [DisplayName("Bail Conditions")]
        public string? BailConditions { get; set; }

        //If the offender has bail, has the bail been breached? Yes, No
        [DisplayName("Bail Breached")]
        public bool BailBreached { get; set; }

        //Is the offender required to be arrested? Yes, No
        [DisplayName("Required to be Arrested")]
        public bool RequiredToBeArrested { get; set; }

        //Is the offender wanted to arrest? Yes, No
        [DisplayName("Wanted to Arrest")]
        public bool WantedToArrest { get; set; }

        //Officer in Charge Name
        [DisplayName("Name")]
        [Required]
        public string? OfficerInChargeName { get; set; }

        //Officer in Charge Email
        [DisplayName("Email")]
        [Required]
        public string? OfficerInChargeEmail { get; set; }

        //Officer in Charge Phone Number
        [DisplayName("Phone")]
        [Required]
        public string? OfficerInChargePhone { get; set; }

        //Victim User name. When a victim logs into the application, they will only see the cases that are linked to them.
        [DisplayName("Victim Username")]
        public string? VictimUserName { get; set; }
    }
}
