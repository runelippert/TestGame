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

            Match newMatch = new Match();

            Match thisMatch = newMatch.setupMatch();

            Board gameBoard = new Board();

            Player players = new Player();

            gameBoard.drawBoard(thisMatch);

            //Turn loop
            for (int turn = 1; turn <= 9; turn++)
            {
                Console.WriteLine();
                Console.WriteLine("Start of turn {0}", turn);
                //Assign orders to all players in the match
                players.giveOrders(thisMatch);

                //Execute Orders
                players.executeOrders(thisMatch);

                //Find encounters - doesn't seem to work
                List<Coordinate> engagements = thisMatch.compairePlayersCoordinates(thisMatch);

                foreach (Coordinate coordinate in engagements)
                {
                    Console.WriteLine("Engagement at {0},{1}", coordinate.x, coordinate.y);
                }

                //Resolve encounters
                Console.WriteLine("!-----New Turn------!");

                gameBoard.drawBoard(thisMatch);
            }



            //Console.WriteLine("new position for {0}: {1},{2}", playerToTakeOrder.name, playerToTakeOrder.position.x, playerToTakeOrder.position.y);
            Rolls roll = new Rolls();

            roll.rollForEngagement(new Coordinate(1, 1), thisMatch);

            
            
      
        }

        


    }
}
