using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.CareerHistory
{
    public class CareerHistoryCreate
    {
        [Required] public string PlayerName { get; set; }
        [Required] public string ClubName { get; set; }
        [Required] public bool IsCurrentlyPlayingFor { get; set; }
    }
}
