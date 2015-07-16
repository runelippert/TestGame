using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BasicActions
    {
        public Actions Action { get; set; }

        public enum Actions
        {
            Down,
            Left,
            Rigth,
            Up,
            Protect
        }

        public static Coordinate TakeAction(Player playerToTakeAction, Actions order)
        {
            Coordinate currentPosition = playerToTakeAction.Position;

            Actions moveTo = order;

            if (order == Actions.Down)
            {
                Console.WriteLine("{0} trying to go down", playerToTakeAction.Name);
                playerToTakeAction.Position.Y++;
                return playerToTakeAction.Position;
            }
            if (order == Actions.Left)
            {
                Console.WriteLine("{0} trying to go left", playerToTakeAction.Name);
                playerToTakeAction.Position.X--;
                return playerToTakeAction.Position;
            }
            if (order == Actions.Rigth)
            {
                Console.WriteLine("{0} trying to go rigth", playerToTakeAction.Name);
                playerToTakeAction.Position.X++;
                return playerToTakeAction.Position;
            }
            if (order == Actions.Up)
            {
                Console.WriteLine("{0} trying to go up", playerToTakeAction.Name);
                playerToTakeAction.Position.Y--;
                return playerToTakeAction.Position;
            }
            if (order == Actions.Protect)
            {
                Console.WriteLine("{0} protecting", playerToTakeAction.Name);
                return playerToTakeAction.Position;
            }
            else
            {
                Console.WriteLine("Could not understand player move");
                return playerToTakeAction.Position;
            }
        }

   
    }
}
