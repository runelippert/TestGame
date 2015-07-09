using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{


    //class playingField
    //{
    //       public Coordinate postion { get; set;}
    //}





    public class Team
    {
        // a list of players 
        public List<Player> playersOnTeam = new List<Player> { };

        public string TeamName { get; set; }
        
    }



    
    class Program
    {

        static void Main(string[] args)
        {
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                homeTeam = firsteTeam,
                awayTeam = secondTeam
            };

            Player players = new Player();

                                   
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(2, 1), team = firsteTeam });
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 2), team = firsteTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1), team = secondTeam});
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(2, 2), team = secondTeam });


            Board gameBoard = new Board();

            gameBoard.drawBoard(thisMatch);


            //Check players at position 1,1
            List<Player> playersAtOneOne = new List<Player>();

            //Get players at 1,1 and add them to the var test. Check if there is anything in the variable test. 
            var test = thisMatch.getPlayersAtCoordinate(new Coordinate(1,1), thisMatch);

            foreach(Player somePayer in test)
            {
                Console.WriteLine(somePayer.name + " is at position 1,1 and is part of team " + somePayer.team.TeamName);
            }

            //Assign orders to all players in the match
            players.giveOrders(thisMatch);

            //Execute Orders
            players.executeOrders(thisMatch);

            //Resolve encounters


            //Console.WriteLine("new position for {0}: {1},{2}", playerToTakeOrder.name, playerToTakeOrder.position.x, playerToTakeOrder.position.y);

            thisMatch.rollForEngagement(new Coordinate(1, 1), thisMatch);

            Console.WriteLine("!-----New Turn------!");
            gameBoard.drawBoard(thisMatch);
      
        }

        


    }
}
