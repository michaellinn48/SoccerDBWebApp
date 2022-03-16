using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.CareerHistory
{
    public class CareerHistoryUpdate
    {
        [Required] public int Id { get; set; }
        [Required] public string PlayerName { get; set; }
        [Required] public string ClubName { get; set; }
        [Required] public bool IsCurrentlyPlayingFor { get; set; }
        [Required] public string StartYear { get; set; }
        [Required] public string EndYear { get; set; }
        [Required] public int Appearances { get; set; }
        [Required] public int Goals { get; set; }

        // FK
        public int? PlayerId { get; set; }
        public int? ClubId { get; set; }
    }
}
