using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Match
    {
            //definition of home Team and away team
            public Team homeTeam { get; set; }

            public Team awayTeam { get; set; }

            public List<Player> playersInMatch()
            {
                List<Player> playersInMatch = new List<Player>();

                foreach (Player x in homeTeam.playersOnTeam)
                {
                    playersInMatch.Add(x);
                }

                foreach (Player x in awayTeam.playersOnTeam)
                {
                    playersInMatch.Add(x);
                }

                return playersInMatch;
            }

            public List<Player> getPlayersAtCoordinate(Coordinate coordinate, Match match)
            {
                List<Player> playersAtCoordinate = new List<Player> { };

                //Check all players coordinate
                foreach (Player somePlayer in match.playersInMatch())
                {
                    if (somePlayer.position.x == coordinate.x)
                        if (somePlayer.position.y == coordinate.y)
                        {
                            playersAtCoordinate.Add(somePlayer);
                        }
                };

                return playersAtCoordinate;
            }
        
    }
}
