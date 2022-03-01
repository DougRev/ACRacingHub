using RacingHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Race
{
    public class RaceEdit
    {
        public int RaceId { get; set; }
        public RaceType RaceType { get; set; }

        [Display(Name = "Title")]
        public string RaceName { get; set; }

        [Display(Name = "Information")]
        public string RaceDescription { get; set;}

        [Display(Name = "Driver Limit")]
        public int DriverLimit { get; set; }
        public DateTime RaceDate { get; set; }
        public DateTimeOffset ModiifedUtc { get; set; }
    }
}
