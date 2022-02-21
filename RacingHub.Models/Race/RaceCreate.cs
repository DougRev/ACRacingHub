using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Race
{
    public class RaceCreate
    {
        public int RaceId { get; set; }
        public Guid OwnerId { get; set; }
        public string RaceName { get; set; }
        public string RaceDescription { get; set; }
        public int DriverLimit { get; set; }
        //public DateTime RaceDate { get; set; }
    }
}
