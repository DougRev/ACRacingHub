using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Team
{
    public class TeamDetails
    {
        [Display(Name = "ID")]
        public int TeamId { get; set; }
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [Display(Name = "Team Info")]
        public string TeamDescription { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
