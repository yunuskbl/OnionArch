﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.APPLICATION.DTOs.AppUser
{
    public class AppUserDTO:BaseDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
