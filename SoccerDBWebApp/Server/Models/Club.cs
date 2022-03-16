using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerDBWebApp.Server.Models
{
    public class Club
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string StadiumName { get; set; }
        public string Manager { get; set; }
        public string ClubLogoImage { get; set; }


        // FK
        public int? LeagueId { get; set; }

        // FK nav prop
        public ICollection<CareerHistory> CareerHistorys { get; set; }
    }
}
