using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Data
{
    public enum CarType { Formual1,  GT, Nascar, IndyCar, F2 }
    public class Race
    {
        [Key]
        public int RaceId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RaceName { get; set;}
        public string RaceDescription { get; set;}
        public DateTime RaceDate { get; set; }
        [Required]
        public int DriverLimit { get; set; }
        public CarType CarType { get; set; }
        //public List<ApplicationUser> Drivers { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        
    }
}
