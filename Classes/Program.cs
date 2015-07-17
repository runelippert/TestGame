using System;
using System.Collections.Generic;

namespace Classes
{
    class Program
    {

        static void Main(string[] args)
        {

            Match newMatch = new Match();

            Match thisMatch = newMatch.SetupMatch();

            Board gameBoard = new Board();

            Player players = new Player();

            var homeTeamHand = thisMatch.HomeTeam.Hand();
            var awayTeamHand = thisMatch.AwayTeam.Hand();

            gameBoard.DrawBoard(thisMatch);

            //Turn loop
            for (int turn = 1; turn <= 9; turn++)
            {
                Console.WriteLine();
                Console.WriteLine("Start of turn {0}", turn);

                //Assign orders to all players in the Home match
                players.GiveOrders(thisMatch.HomeTeam, homeTeamHand);

                //Assign orders to all players in the away team
                players.GiveOrders(thisMatch.AwayTeam, awayTeamHand);

                //Execute Orders
                players.ExecuteOrders(thisMatch);

                //Find encounters - doesn't seem to work
                List<Coordinate> engagements = thisMatch.CompairePlayersCoordinates(thisMatch);
                Rolls roll = new Rolls();

                foreach (Coordinate coordinate in engagements)
                {
                    Console.WriteLine("Engagement at {0},{1}", coordinate.X, coordinate.Y);
                    roll.RollForEngagement(coordinate, thisMatch);
                }

                Console.WriteLine("!-----New Turn------!");

                gameBoard.DrawBoard(thisMatch);
            }
        }
    }
}
