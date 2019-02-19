using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Abuse.Models
{
    public class Complain
    {
        public int ID { get; set; }

        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReportDate { get; set; }

        [Display(Name = "Date Of Incident")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfIncident { get; set; }

        [Display(Name = "Victim Name")]
        [StringLength(60, ErrorMessage = "Victim name too short", MinimumLength = 5)]
        [Required]
        [DataType(DataType.Text)]
        public string VictimName { get; set; }

        [Display(Name ="Accussed")]
        [StringLength(60, ErrorMessage ="Name Of Accussed too short", MinimumLength = 5)]
        [Required]
        [DataType(DataType.Text)]
        public string Accused { get; set; }

        [Display(Name ="Place Of Incident")]
        [StringLength(200, ErrorMessage = "Invalid Address. Address too short", MinimumLength = 10)]
        public string PlaceOfIncident { get; set; }

        [Display(Name ="Address Of Victim")]
        [StringLength(200,ErrorMessage ="Invalid Address. Address too short",MinimumLength =10)]
        public string AddressOfVictim { get; set; }

        [Display(Name ="Address Of Accussed")]
        [StringLength(200, ErrorMessage = "Invalid Address. Address too short", MinimumLength = 10)]
        public string AddressOfAccussed { get; set; }
    }
}
