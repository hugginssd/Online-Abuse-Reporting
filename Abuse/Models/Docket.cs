using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abuse.Models
{
    public class Docket
    {
        public int ID { get; set; }

        [Display(Name="Docket Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(60,ErrorMessage ="Offender name too short",MinimumLength =5)]
        public string Accussed { get; set; }

        [Display(Name ="Accused Description")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(150,ErrorMessage ="Description too short. Add a few more information to help the investigation.",MinimumLength =5)]
        public string AccussedDescription { get; set; }

        [Display(Name = "Offense")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(15, ErrorMessage = "Offense too short", MinimumLength = 3)]
        public string Offense { get; set; }

        [Display(Name = "Date Of Offense")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfOffense { get; set; }

        [Display(Name = "Victim Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "Name too short", MinimumLength = 5)]
        public string Victim { get; set; }

        [Display(Name = "Address Of Offender")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "Invalid address. Address too short", MinimumLength = 5)]
        public string AddressOfOffender { get; set; }

        [Display(Name = "Officer On Case")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "Name to short", MinimumLength = 5)]
        public string OfficerOnCase { get; set; }

        [Display(Name = "Investigative Officer")]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "Name to short", MinimumLength = 5)]
        public string InvestigativeOfficer { get; set; }
    }
}
