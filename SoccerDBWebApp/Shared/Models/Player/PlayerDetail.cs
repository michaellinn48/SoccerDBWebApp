using SoccerDBWebApp.Shared.Models.CareerHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Shared.Models.Player
{
    public class PlayerDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public string Positions { get; set; }
        public string PlayerImage { get; set; }

        public ICollection<CareerHistoryListItem> CareerHistorys { get; set; }
    }
}
