﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.Race
{
    public class RaceCreate
    {
        [Display(Name = "ID")]
        public int RaceId { get; set; }
        public Guid OwnerId { get; set; }
        [Display(Name = "Title")]
        public string RaceName { get; set; }
        [Display(Name = "Information")]
        public string RaceDescription { get; set; }
        [Display(Name = "Driver Limit")]
        public int DriverLimit { get; set; }
        public DateTime RaceDate { get; set; }
    }
}
