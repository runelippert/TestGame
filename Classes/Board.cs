using System;
using System.Collections.Generic;

namespace Classes
{
    public class Board
    {
        public void DrawBoard(Match match)
        {
            foreach (Coordinate coordinate in BoardCordinates())
            {

                List<Player> playersAtCoordinate = match.GetPlayersAtCoordinate(coordinate, match);

                if (coordinate.Y == 0)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 0 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 1)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 1 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 2)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 2 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 3)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 3 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 4)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 4 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 5)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 5 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 6)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 6 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.Y == 7)
                {
                    DrawRow(coordinate.Y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.Y == 7 && coordinate.X == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
            }
            
        }

        void DrawRow(int y, Match match, List<Player> playersAtCoordinate, Coordinate coordinate)
        {
            Console.Write("|");
            if (playersAtCoordinate.Count > 0)
            {
                foreach (var player in match.GetPlayersAtCoordinate(coordinate, match))
                {
                    Console.Write(player.Name + " ");
                    if (match.MatchBall.PlayerWithBall == player)
                    {
                        Console.Write("(o)");
                    }
                    if (player.State == Player.PlayerState.Down)
                    {
                        Console.Write("(down)");
                    }
                }
            }
            Console.Write("{0},{1}", coordinate.X, coordinate.Y);
        }


        public List<Coordinate> BoardCordinates()
        {
            List<Coordinate> boardCordinates = new List<Coordinate>();
                        
            //i = number of rows on the board
            for (int i = 0; i <= 7; i++)
            {
                boardCordinates.Add(new Coordinate(0, i));
                boardCordinates.Add(new Coordinate(1, i));
                boardCordinates.Add(new Coordinate(2, i));
            }

            return boardCordinates;
        }

    }

    public class Coordinate
    {
        public Coordinate(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate))
            {
                return false;
            }
            Coordinate coordinate = (Coordinate)obj;
            return ((coordinate.X == this.X) && (coordinate.Y == this.Y));
        }

    }
}
