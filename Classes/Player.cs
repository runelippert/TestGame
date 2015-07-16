using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Player
    {
        public int ShirtNumber { get; set; }
        public string Name { get; set; }
        public Coordinate Position { get; set; }
        public Team Team { get; set; }
        public BasicActions Action { get; set; }
        public PlayerState State { get; set; }

        
        public enum PlayerState
        {
            Up,
            Down
        }
        
        public void GiveOrders(Match match)
        {
            //Give players orders
            //foreach players in match to give them orders
            foreach (Player player in match.PlayersInMatch(match))
            {
                Console.WriteLine("{0} spiller for {1} med nummer {2}", player.Name, player.Team.TeamName, player.ShirtNumber);
                Console.WriteLine("Give order to {0}", player.Name);

                //Get Direction


                Console.WriteLine("Hit arrowkey for direction to move or space to protect for {0}: ", player.Name);
                var action = new BasicActions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                //{
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        action.Action = BasicActions.Actions.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        action.Action = BasicActions.Actions.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        action.Action = BasicActions.Actions.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        action.Action = BasicActions.Actions.Rigth;
                        break;
                    case ConsoleKey.Spacebar:
                        action.Action = BasicActions.Actions.Protect;
                        break;
                }
                //}

                //Assign player Order
                player.Action = action;

                Console.WriteLine(player.Name + " has the action " + player.Action.Action);
                Console.WriteLine("----------------------------");
            }

    }

        public void ExecuteOrders(Match match)
        {
            foreach (Player player in match.PlayersInMatch(match))
            {
                BasicActions.TakeAction(player, player.Action.Action);
            }
        }
    
    }
}
