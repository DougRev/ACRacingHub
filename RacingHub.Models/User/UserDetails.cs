﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacingHub.Models.User
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}