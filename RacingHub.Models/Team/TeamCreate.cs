using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Team
{
    public class TeamCreate
    {
        public int TeamId { get; set; }
        public Guid OwnerId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
    }
}
