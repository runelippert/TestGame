using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Rolls
    {
        public int rollD6()
        {
                Random rnd = new Random();

                int result = rnd.Next(1, 7);

                return result;
        }

        public enum resultOfEngagement
        {
            homeTeam,
            awayTeam,
            Tie
        }

        public resultOfEngagement findWinner(Team one, int rollOne, Team two, int rollTwo)
        {
            if (rollOne > rollTwo)
            {
                Console.WriteLine(one.TeamName + " is the winner");
                return resultOfEngagement.homeTeam;
            }
            else if (rollOne < rollTwo)
            {
                Console.WriteLine(two.TeamName + " is the winner");
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

            resultOfEngagement result = roll.findWinner(match.homeTeam, modifiedGreekRoll, match.awayTeam, modifiedOlsenRoll);

            Console.WriteLine(result.ToString());


        }
        

    }
}
