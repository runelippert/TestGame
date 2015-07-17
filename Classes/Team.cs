using System.Collections.Generic;

namespace Classes
{
    public class Team
    {
        public string TeamName { get; set; }   

        // a list of players 
        public List<Player> PlayersOnTeam = new List<Player>();


        public List<Player.Orders> Hand()
        {
            List<Player.Orders> hand = new List<Player.Orders>
            {
                Player.Orders.DobbelMove, 
                Player.Orders.DirtyProtection
            };


            return hand;
        }



    }
}