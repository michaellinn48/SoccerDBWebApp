﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.Club
{
    public class ClubCreate
    {
        [Required] public string Name { get; set; }
    }
}
