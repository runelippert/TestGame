using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BasicActions
    {
        public Actions action { get; set; }

        public enum Actions
        {
            down,
            left,
            rigth,
            up,
            protect
        }

        public static Coordinate takeAction(Player playerToTakeAction, Actions order)
        {
            Coordinate currentPosition = playerToTakeAction.position;

            BasicActions.Actions moveTo = order;

            if (order == BasicActions.Actions.down)
            {
                Console.WriteLine("{0} trying to go down", playerToTakeAction.name);
                playerToTakeAction.position.y++;
                return playerToTakeAction.position;
            }
            if (order == BasicActions.Actions.left)
            {
                Console.WriteLine("{0} trying to go left", playerToTakeAction.name);
                playerToTakeAction.position.x--;
                return playerToTakeAction.position;
            }
            if (order == BasicActions.Actions.rigth)
            {
                Console.WriteLine("{0} trying to go rigth", playerToTakeAction.name);
                playerToTakeAction.position.x++;
                return playerToTakeAction.position;
            }
            if (order == BasicActions.Actions.up)
            {
                Console.WriteLine("{0} trying to go up", playerToTakeAction.name);
                playerToTakeAction.position.y--;
                return playerToTakeAction.position;
            }
            if (order == BasicActions.Actions.protect)
            {
                Console.WriteLine("{0} protecting", playerToTakeAction.name);
                return playerToTakeAction.position;
            }
            else
            {
                Console.WriteLine("Could not understand player move");
                return playerToTakeAction.position;
            }
        }

   
    }
}
