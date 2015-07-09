﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Player
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

    public class Coordinate
    {
        public Coordinate(int _x, int _y) {
        x = _x;
        y = _y;
    }
    public int x { get; set; }
    public int y { get; set; }

       
    }



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



            Console.WriteLine("select player:");
            Console.WriteLine("1 = " + firsteTeam.playersOnTeam[0].name);
            Console.WriteLine("2 = " + firsteTeam.playersOnTeam[1].name);
            Console.WriteLine("3 = " + secondTeam.playersOnTeam[0].name);
            Console.WriteLine("4 = " + secondTeam.playersOnTeam[1].name);

            var selectPlayer = Console.ReadLine();
            var playerToTakeOrder = new Player();

            switch (selectPlayer)
            {
                case "1":
                    playerToTakeOrder = firsteTeam.playersOnTeam[0];
                    break;
                case "2":
                    playerToTakeOrder = firsteTeam.playersOnTeam[1];
                    break;
                case "3":
                    playerToTakeOrder = secondTeam.playersOnTeam[0];
                    break;
                case "4":
                    playerToTakeOrder = secondTeam.playersOnTeam[1];
                    break;
            }

            Console.WriteLine("Hit arrowkey for direction to move {0}: ", playerToTakeOrder.name);
            var order = new BasicActions.moves();

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            //while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            //{
                switch(keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        order = BasicActions.moves.down;
                        break;
                    case ConsoleKey.DownArrow:
                        order = BasicActions.moves.up;
                        break;
                    case ConsoleKey.LeftArrow:
                        order = BasicActions.moves.left;
                        break;
                    case ConsoleKey.RightArrow:
                        order = BasicActions.moves.rigth;
                        break;
                }
            //}




            BasicActions.movePlayer(playerToTakeOrder, order);

            Console.WriteLine("new position for {0}: {1},{2}", playerToTakeOrder.name, playerToTakeOrder.position.x, playerToTakeOrder.position.y);

            thisMatch.rollForEngagement(new Coordinate(1, 1), thisMatch);

            gameBoard.drawBoard(thisMatch);
      
        }

        


    }
}
