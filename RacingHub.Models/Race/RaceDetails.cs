using RacingHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Race
{
    public class RaceDetails
    {
        [Display(Name = "ID")]
        public int RaceId { get; set; }
        public CarType CarType { get; set; }

        [Display(Name = "Event Date")]
        public DateTime RaceDate { get; set; }

        [Display(Name = "Title")]
        public string RaceName { get; set;}
        [Display(Name = "Information")]
        public string RaceDescription { get; set;}
        [Display(Name = "Driver Limit")]
        public int DriverLimit { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
