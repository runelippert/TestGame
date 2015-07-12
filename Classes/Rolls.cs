using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Rolls
    {

        public enum resultOfEngagement
        {
            homeTeam,
            awayTeam,
            Tie
        }

        public resultOfEngagement findWinner(Match match, int homeTeamRoll, int awayTeamRoll)
        {
            if (homeTeamRoll > awayTeamRoll)
            {
                Console.WriteLine(match.homeTeam.TeamName + " is the winner");
                return resultOfEngagement.homeTeam;
            }
            else if (homeTeamRoll < awayTeamRoll)
            {
                Console.WriteLine(match.awayTeam.TeamName + " is the winner");
                return resultOfEngagement.awayTeam;
            }
            else
            {
                Console.WriteLine("its a tie");
                return resultOfEngagement.Tie;
            }

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
            Random rnd = new Random();

            int rollHome = rnd.Next(1, 7);
            int rollAway = rnd.Next(1, 7);

            Console.WriteLine(match.homeTeam.TeamName + " rolls " + rollHome);
            Console.WriteLine(match.awayTeam.TeamName + " rolls " + rollAway);

            //+2 til roll pr. player at coordinate.
            int modifiedGreekRoll = rollHome + greekPlayersAtCoordinate.Count * 2;
            int modifiedOlsenRoll = rollAway + olsenPlayerAtCoordinate.Count * 2;

            Console.WriteLine("greek modified roll is" + modifiedGreekRoll);
            Console.WriteLine("Olsen modified roll is" + modifiedOlsenRoll);

            resultOfEngagement result = findWinner(match, modifiedGreekRoll, modifiedOlsenRoll);

            Console.WriteLine(result.ToString());


        }
        

    }
}
