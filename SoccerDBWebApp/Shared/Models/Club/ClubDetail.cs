﻿using SoccerDBWebApp.Shared.Models.CareerHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.Club
{
    public class ClubDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string StadiumName { get; set; }
        public string Manager { get; set; }
        public string ClubLogoImage { get; set; }

        public int? LeagueId { get; set; }
        public ICollection<CareerHistoryListItem> CareerHistorys { get; set; }
    }
}
