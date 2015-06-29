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

        //This doesn't work, even if postion and coordinate are the same, they don't get added to the list. 
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

    class Team
    {
        // a list of players 
        public List<Player> playersOnTeam = new List<Player> { };
        
    }

    /// <summary>
    /// Basic actions that if allowed, any player can use at any time. 
    /// </summary>
    class BasicActions
    {
        public moves move { get; set; }
        public enum moves
        {
            forward,
            left,
            rigth,
            back
        }

        public static Coordinate movePlayer(Player playerToMove, moves order)
        {
            Coordinate currentPosition = playerToMove.position;

            BasicActions.moves moveTo = order;

            if (moveTo == BasicActions.moves.forward)
            {
                Console.WriteLine("{0} trying to go forward", playerToMove.name);
                playerToMove.position.y++;
                return playerToMove.position;
            }
            if (moveTo == BasicActions.moves.left)
            {
                Console.WriteLine("{0} trying to go left", playerToMove.name);
                playerToMove.position.x--;
                return playerToMove.position;
            }
            if (moveTo == BasicActions.moves.rigth)
            {
                Console.WriteLine("{0} trying to go rigth", playerToMove.name);
                playerToMove.position.x++;
                return playerToMove.position;
            }
            if (moveTo == BasicActions.moves.back)
            {
                Console.WriteLine("{0} trying to go back", playerToMove.name);
                playerToMove.position.y--;
                return playerToMove.position;
            }
            else
            {
                Console.WriteLine("Could not understand player move");
                return playerToMove.position;
            }         
        }
    }

    

    
    class Program
    {
        static void Main(string[] args)
        {
            Team firsteTeam = new Team();
            Team secondTeam = new Team();

            Match thisMatch = new Match()
            {
                homeTeam = firsteTeam,
                awayTeam = secondTeam
            };
                                   
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(1, 1) });
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 1) });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1) });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(1, 2) });


            //Check players at position 1,1
            List<Player> playersAtOneOne = new List<Player>();

            //Get players at 1,1 and add them to the var test. Check if there is anything in the variable test. 
            var test = thisMatch.getPlayersAtCoordinate(new Coordinate(1,1), thisMatch);

            foreach(Player somePayer in test)
            {
                Console.WriteLine(somePayer.name + " is at position 1,1");
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

      
        }


    }
}
