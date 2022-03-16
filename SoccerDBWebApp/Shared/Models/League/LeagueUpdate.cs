using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.League
{
    public class LeagueUpdate
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Country { get; set; }
        [Required] public int TierLevel { get; set; }
        [Required] public string LeagueLogoImage { get; set; }
    }
}
