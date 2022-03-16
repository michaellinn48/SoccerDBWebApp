using System.ComponentModel.DataAnnotations;

namespace SoccerDBWebApp.Server.Models
{
    public class CareerHistory
    {
        [Key] public int Id { get; set; }
        [Required] public string PlayerName { get; set; }
        [Required] public string ClubName { get; set; }
        [Required] public bool IsCurrentlyPlayingFor { get; set; }

        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int Appearances { get; set; }
        public int Goals { get; set; }


        // FK        
        public int? PlayerId { get; set; }
        public int? ClubId { get; set; }
    }
}
