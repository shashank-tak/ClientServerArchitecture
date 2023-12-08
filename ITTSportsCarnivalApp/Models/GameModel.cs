using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp.Models
{
    public class GameModel
    {
        public int gameType { get; set; }
        public List<PlayerModel> players { get; set; }
    }
}
