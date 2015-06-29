using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Player
    {
        public int shirtNumber { get; set; }
        public string name { get; set; }
        public Coordinate position { get; set; }
        public Team team { get; set; }

    }

    //class playingField
    //{
    //       public Coordinate postion { get; set;}
    //}

    class Coordinate
    {
        public Coordinate(int _x, int _y) {
        x = _x;
        y = _y;
    }
    public int x { get; set; }
    public int y { get; set; }

       
    }



    class Team
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
                                   
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(2, 1), team = firsteTeam });
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 2), team = firsteTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1), team = secondTeam});
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(2, 2), team = secondTeam });


            //Check players at position 1,1
            List<Player> playersAtOneOne = new List<Player>();

            //Get players at 1,1 and add them to the var test. Check if there is anything in the variable test. 
            var test = thisMatch.getPlayersAtCoordinate(new Coordinate(1,1), thisMatch);


            foreach(Player somePayer in test)
            {
                Console.WriteLine(somePayer.name + " is at position 1,1 and is part of team " + somePayer.team.TeamName);
            }



                        
            //Console.WriteLine("Player {0}'s position is {1},{2}", firsteTeam.playersOnTeam[0].shirtNumber, firsteTeam.playersOnTeam[0].position.x, firsteTeam.playersOnTeam[0].position.y);
            //Console.WriteLine("Player {0}'s position is {1},{2}", firsteTeam.playersOnTeam[1].shirtNumber, firsteTeam.playersOnTeam[1].position.x, firsteTeam.playersOnTeam[1].position.y);

            //list all players in match

            Console.WriteLine("Type direction to move Player: ");
            var giveOrder = Console.ReadLine();
            var order = new BasicActions.moves();

            switch(giveOrder)
            {
                case "left":
                    order = BasicActions.moves.left;
                    break;
                case "rigth":
                    order = BasicActions.moves.rigth;
                    break;
                case "forward":
                    order = BasicActions.moves.forward;
                    break;
                case "back":
                    order = BasicActions.moves.back;
                    break;

            }

            Console.WriteLine("select player by typeing 1 or 2");
            var selectPlayer = Console.ReadLine();
            var playerToTakeOrder = new Player();

            switch(selectPlayer)
            {
                case "1":
                    playerToTakeOrder = firsteTeam.playersOnTeam[0];
                    break;
                case "2":
                    playerToTakeOrder = firsteTeam.playersOnTeam[1];
                    break;

            }

            BasicActions.movePlayer(playerToTakeOrder, order);

            Console.WriteLine("new position for {0}: {1},{2}", playerToTakeOrder.name, playerToTakeOrder.position.x, playerToTakeOrder.position.y);

            List<Player> greekPlayersAtCoordinate = new List<Player>();
            List<Player> olsenPlayerAtCoordinate = new List<Player>();

            foreach (Player somePlayer in thisMatch.getPlayersAtCoordinate(new Coordinate(2, 2), thisMatch))
            {
                if (somePlayer.team.TeamName == firsteTeam.TeamName)
                {
                    greekPlayersAtCoordinate.Add(somePlayer);
                }
                else
                {
                    olsenPlayerAtCoordinate.Add(somePlayer);
                }
            }

            Console.WriteLine(firsteTeam.TeamName + " has " + greekPlayersAtCoordinate.Count + " players at coordinate 2,2");
            Console.WriteLine(secondTeam.TeamName + " has " + olsenPlayerAtCoordinate.Count + " players at coordinate 2,2");

      
        }


    }
}
