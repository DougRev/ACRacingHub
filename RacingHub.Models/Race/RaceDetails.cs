using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Race
{
    public class RaceDetails
    {
        public int RaceId { get; set; }
        public string RaceName { get; set;}
        public string RaceDescription { get; set;}  
        public int DriverLimit { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
