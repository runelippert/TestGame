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

            //Assign orders to all players in the match
            players.giveOrders(thisMatch);

            //Execute Orders
            players.executeOrders(thisMatch);

            //Resolve encounters


            //Console.WriteLine("new position for {0}: {1},{2}", playerToTakeOrder.name, playerToTakeOrder.position.x, playerToTakeOrder.position.y);
            Rolls roll = new Rolls();

            roll.rollForEngagement(new Coordinate(1, 1), thisMatch);

            Console.WriteLine("!-----New Turn------!");
            gameBoard.drawBoard(thisMatch);
      
        }

        


    }
}
