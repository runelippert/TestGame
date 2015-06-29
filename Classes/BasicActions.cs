using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
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
}
