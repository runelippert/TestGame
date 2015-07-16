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

        public Player effectOfEngangement(resultOfEngagement result, List<Player> homeTeamPlayersAtCoordinate, List<Player> awayTeamPlayersAtCoordinate)
        {
            Random rnd = new Random();

            if (result == resultOfEngagement.homeTeam)
            {
                //Select a random player from away team and set to downed.
                var NumberOfawayPlayersAtCoordinate = awayTeamPlayersAtCoordinate.Count;
                int selectRandomPlayer = rnd.Next(0, NumberOfawayPlayersAtCoordinate); //rnd.next max is 1 lower then the number writen.

                //select Player to take effekt
                var player = awayTeamPlayersAtCoordinate[selectRandomPlayer];
                
                //Set player to downed
                player.state = Player.playerState.down;

                Console.WriteLine("{0} is {1} from the team {2}", player.name,
                    player.state, player.team.TeamName);

                return player;
            }
            //Away team must be the winner
            else
            {
                //Select a random player from home team and set to downed.
                var NumberOfhomePlayersAtCoordinate = homeTeamPlayersAtCoordinate.Count;
                int selectRandomPlayer = rnd.Next(0, NumberOfhomePlayersAtCoordinate);

                //select Player to take effekt
                var player = homeTeamPlayersAtCoordinate[selectRandomPlayer];

                //Set player to downed
                player.state = Player.playerState.down;

                Console.WriteLine("{0} is {1} from the team {2}", player.name,
                    player.state, player.team.TeamName);

                return player;
            }
        }

        /// <summary>
        /// Finds number of players for each team at a coordinate at rolls to find a winner
        /// 
        /// </summary>
        public void rollForEngagement(Coordinate coordinate, Match match)
        {
            List<Player> homePlayersAtCoordinate = new List<Player>();
            List<Player> awayPlayerAtCoordinate = new List<Player>();

            foreach (Player somePlayer in match.getPlayersAtCoordinate(coordinate, match))
            {
                if (somePlayer.team.TeamName == match.homeTeam.TeamName)
                {
                    homePlayersAtCoordinate.Add(somePlayer);
                }
                else
                {
                    awayPlayerAtCoordinate.Add(somePlayer);
                }
            }

            Console.WriteLine(match.homeTeam.TeamName + " has " + homePlayersAtCoordinate.Count + " players at coordinate 2,2");
            Console.WriteLine(match.awayTeam.TeamName + " has " + awayPlayerAtCoordinate.Count + " players at coordinate 2,2");

            //roll for greek players at coordinate
            Random rnd = new Random();

            int rollHome = rnd.Next(1, 7);
            int rollAway = rnd.Next(1, 7);

            Console.WriteLine(match.homeTeam.TeamName + " rolls " + rollHome);
            Console.WriteLine(match.awayTeam.TeamName + " rolls " + rollAway);

            //+2 til roll pr. player at coordinate.
            int modifiedGreekRoll = rollHome + homePlayersAtCoordinate.Count * 2;
            int modifiedOlsenRoll = rollAway + awayPlayerAtCoordinate.Count * 2;

            Console.WriteLine("greek modified roll is" + modifiedGreekRoll);
            Console.WriteLine("Olsen modified roll is" + modifiedOlsenRoll);

            resultOfEngagement engagementResult = findWinner(match, modifiedGreekRoll, modifiedOlsenRoll);

            //add effect (down player, equals half a player next round and can't move.
            if (engagementResult != resultOfEngagement.Tie)
            {
                effectOfEngangement(engagementResult, homePlayersAtCoordinate, awayPlayerAtCoordinate);
            }
            else
            {
                Console.WriteLine("Its was a tie, no player downed");
            }

            //EffectOfEngagement (player at coordinate from loosing team)

            //If home team wins the engangement


            Console.WriteLine(engagementResult.ToString());


        }
        

    }
}
