using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerDBWebApp.Server.Models
{
    public class League
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public string Country { get; set; }
        public int TierLevel { get; set; }
        public string LeagueLogoImage { get; set; }


        // FK nav prop
        public ICollection<Club> Clubs { get; set; }
    }
}
