using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Data
{
    public class Enrollment
    {
        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }

        [ForeignKey(nameof(Race))]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int UserId { get; set; }
    }
}
