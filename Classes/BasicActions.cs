using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BasicActions
    {
        public moves move { get; set; }
        public enum moves
        {
            down,
            left,
            rigth,
            up
        }

        public static Coordinate movePlayer(Player playerToMove, moves order)
        {
            Coordinate currentPosition = playerToMove.position;

            BasicActions.moves moveTo = order;

            if (moveTo == BasicActions.moves.down)
            {
                Console.WriteLine("{0} trying to go down", playerToMove.name);
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
            if (moveTo == BasicActions.moves.up)
            {
                Console.WriteLine("{0} trying to go up", playerToMove.name);
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
}
