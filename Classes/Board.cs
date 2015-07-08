﻿using System;
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
            for(int i = 0; i <= 7; i++)
            {
                drawRow(i, match);               
            }
        }

        void drawRow(int y, Match match)
        {
            List<Coordinate> fieldPoistionsRow1 = new List<Coordinate>();

            fieldPoistionsRow1.Add(new Coordinate(0, y));
            fieldPoistionsRow1.Add(new Coordinate(1, y));
            fieldPoistionsRow1.Add(new Coordinate(2, y));

            foreach (var coordinate in fieldPoistionsRow1)
            {
                List<Player> playersAtCoordinate = match.getPlayersAtCoordinate(coordinate, match);

                Console.Write("|");
                if (playersAtCoordinate.Count > 0)
                {
                    Console.Write(match.getPlayersAtCoordinate(coordinate, match)[0].name);
                }
                Console.Write("{0},{1}", coordinate.x, coordinate.y);
            }

            Console.WriteLine("|");
            Console.WriteLine("-----------------------------");

        }
    }
}