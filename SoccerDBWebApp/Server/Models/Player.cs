using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoccerDBWebApp.Server.Models
{
    public class Player
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        //public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Positions { get; set; }
        public string PlayerImage { get; set; }


        // FK nav prop
        public ICollection<CareerHistory> CareerHistorys { get; set; }
    }
}
