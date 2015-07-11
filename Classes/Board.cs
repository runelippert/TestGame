using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Board
    {
        public void drawBoard(Match match)
        {
            foreach (Coordinate coordinate in boardCordinates())
            {

                List<Player> playersAtCoordinate = match.getPlayersAtCoordinate(coordinate, match);

                if (coordinate.y == 0)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 0 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 1)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 1 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 2)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 2 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 3)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 3 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 4)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 4 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 5)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 5 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 6)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 6 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
                if (coordinate.y == 7)
                {
                    drawRow(coordinate.y, match, playersAtCoordinate, coordinate);
                }
                if (coordinate.y == 7 && coordinate.x == 2)
                {
                    Console.Write("|");
                    Console.WriteLine("");
                    Console.WriteLine("---------------------");
                }
            }
            
        }

        void drawRow(int y, Match match, List<Player> playersAtCoordinate, Coordinate coordinate)
        {
            Console.Write("|");
            if (playersAtCoordinate.Count > 0)
            {
                foreach (var x in match.getPlayersAtCoordinate(coordinate, match))
                {
                    Console.Write(x.name + " ");
                }
            }
            Console.Write("{0},{1}", coordinate.x, coordinate.y);
        }


        public List<Coordinate> boardCordinates()
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
            x = _x;
            y = _y;
        }
        public int x { get; set; }
        public int y { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate))
            {
                return false;
            }
            Coordinate coordinate = (Coordinate)obj;
            return ((coordinate.x == this.x) && (coordinate.y == this.y));
        }

    }
}
