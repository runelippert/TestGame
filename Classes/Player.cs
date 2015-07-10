using System;
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
        public BasicActions action { get; set; }

        public void giveOrders(Match match)
        {
            //Give players orders
            //try to do a foreach in players in match to give them orders
            foreach (Player player in match.playersInMatch(match))
            {
                Console.WriteLine("{0} spiller for {1} med nummer {2}", player.name, player.team.TeamName, player.shirtNumber);
                Console.WriteLine("Give order to {0}", player.name);

                //Get Direction


                Console.WriteLine("Hit arrowkey for direction to move or space to protect for {0}: ", player.name);
                var action = new BasicActions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                //while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                //{
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        action.action = BasicActions.Actions.up;
                        break;
                    case ConsoleKey.DownArrow:
                        action.action = BasicActions.Actions.down;
                        break;
                    case ConsoleKey.LeftArrow:
                        action.action = BasicActions.Actions.left;
                        break;
                    case ConsoleKey.RightArrow:
                        action.action = BasicActions.Actions.rigth;
                        break;
                    case ConsoleKey.Spacebar:
                        action.action = BasicActions.Actions.protect;
                        break;
                }
                //}

                //Assign player Order
                player.action = action;

                Console.WriteLine(player.name + " has the action " + player.action.action);
                Console.WriteLine("----------------------------");



            }

    }

        public void executeOrders(Match match)
        {
            foreach (Player player in match.playersInMatch(match))
            {
                BasicActions.takeAction(player, player.action.action);
            }
        }
    
    }
}
