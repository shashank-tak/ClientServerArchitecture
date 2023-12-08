using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTSportsCarnivalApp.Models
{
    public class PlayerModel
    {
        public PlayerModel(int PlayerId, string Name)
        {
            playerId = PlayerId;
            name = Name;
        }
        public int playerId { get; set; }
        public string name { get; set; }
    }
}
