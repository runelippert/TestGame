using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Match
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
            
            /// <summary>
            /// Finds number of players for each team at a coordinate at rolls to find a winner
            /// 
            /// </summary>
            public void rollForEngagement(Coordinate coordinate, Match match)
            {
                List<Player> greekPlayersAtCoordinate = new List<Player>();
                List<Player> olsenPlayerAtCoordinate = new List<Player>();

                foreach (Player somePlayer in match.getPlayersAtCoordinate(new Coordinate(2, 2), match))
                {
                    if (somePlayer.team.TeamName == match.homeTeam.TeamName)
                    {
                        greekPlayersAtCoordinate.Add(somePlayer);
                    }
                    else
                    {
                        olsenPlayerAtCoordinate.Add(somePlayer);
                    }
                }

                Console.WriteLine(match.homeTeam.TeamName + " has " + greekPlayersAtCoordinate.Count + " players at coordinate 2,2");
                Console.WriteLine(match.awayTeam.TeamName + " has " + olsenPlayerAtCoordinate.Count + " players at coordinate 2,2");

                //roll for greek players at coordinate
                Rolls roll = new Rolls();

                int rollGreek = roll.rollD6();
                int rollOlsen = roll.rollD6();

                Console.WriteLine(match.homeTeam.TeamName + " rolls " + roll.rollD6());
                Console.WriteLine(match.awayTeam.TeamName + " rolls " + roll.rollD6());

                //+2 til roll pr. player at coordinate.
                int modifiedGreekRoll = rollGreek + greekPlayersAtCoordinate.Count * 2;
                int modifiedOlsenRoll = rollOlsen + olsenPlayerAtCoordinate.Count * 2;

                Console.WriteLine("greek modified roll is" + modifiedGreekRoll);
                Console.WriteLine("Olsen modified roll is" + modifiedOlsenRoll);

                string result = roll.findWinner(homeTeam, modifiedGreekRoll, awayTeam, modifiedOlsenRoll);

                Console.WriteLine(result);


            }
        
    }
}
