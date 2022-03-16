using SoccerDBWebApp.Shared.Models.CareerHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.Player
{
    public class PlayerUpdate
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        //[Required] public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Positions { get; set; }
        public string PlayerImage { get; set; }

    }
}
