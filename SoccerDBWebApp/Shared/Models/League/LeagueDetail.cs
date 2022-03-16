using SoccerDBWebApp.Shared.Models.Club;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.League
{
    public class LeagueDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int TierLevel { get; set; }
        public string LeagueLogoImage { get; set; }

        public ICollection<ClubListItem> Clubs { get; set; }
    }
}
