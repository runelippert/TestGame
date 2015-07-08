using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Board
    {
        public void drawBoard()
        {
            for(int i = 0; i <= 7; i++)
            {
                drawRow(i);               
            }
        }

        void drawRow(int y)
        {
            List<Coordinate> fieldPoistionsRow1 = new List<Coordinate>();

            fieldPoistionsRow1.Add(new Coordinate(0, y));
            fieldPoistionsRow1.Add(new Coordinate(1, y));
            fieldPoistionsRow1.Add(new Coordinate(2, y));

            foreach (var coordinate in fieldPoistionsRow1)
            {
                Console.Write("|");
                Console.Write("{0},{1}", coordinate.x, coordinate.y);
            }

            Console.WriteLine("|");
            Console.WriteLine("-----------------------------");

        }
    }
}
