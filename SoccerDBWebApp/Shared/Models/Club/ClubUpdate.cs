using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.Club
{
    public class ClubUpdate
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }
        [Required] public string StadiumName { get; set; }
        [Required] public string Manager { get; set; }
        [Required] public string ClubLogoImage { get; set; }

        public int? LeagueId { get; set; }
    }
}
