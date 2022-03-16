using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.CareerHistory
{
    public class CareerHistoryListItem
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string ClubName { get; set; }
        public bool IsCurrentlyPlayingFor { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int Appearances { get; set; }
        public int Goals { get; set; }
        public int? PlayerId { get; set; }
        public int? ClubId { get; set; }
    }
}
