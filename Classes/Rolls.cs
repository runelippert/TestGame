using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Rolls
    {
        public int rollD6()
        {
                Random rnd = new Random();

                int result = rnd.Next(1, 7);

                return result;
        }

        public string findWinner(Team one, int rollOne, Team two, int rollTwo)
        {
            if (rollOne > rollTwo)
            {
                return one.TeamName + " is the winner";
            }
            else if (rollOne < rollTwo)
            {
                return two.TeamName + " is the winner";
            }
            else
            {
                return "its a tie";
            }

        }

    }
}
