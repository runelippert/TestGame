﻿using System;
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
        public PlayerState State { get; set; }
        public Orders PlayerOrder { get; set; }

        
        public enum PlayerState
        {
            Up,
            Down
        }
        
        public void GiveOrders(Team teamToGiveOrders, List<Orders> hand)
        {
            //Give players orders
            //foreach players in match to give them orders
            foreach (Player player in teamToGiveOrders.PlayersOnTeam)
            {
                if (player.State == PlayerState.Up)
                {
                    Console.WriteLine("{0} spiller for {1} med nummer {2}", player.Name, player.Team.TeamName, player.ShirtNumber);
                    Console.WriteLine("Give order to {0}", player.Name);

                    Console.WriteLine("#### YOUR HAND ####");
                    Console.WriteLine("You have the following Orders on your Hand:");
                    //Write the orders the player has

                    for (int index = 0; index < hand.Count; index++)
                    {
                        var card = hand[index];
                        Console.Write("#" + index);
                        Console.WriteLine(" " + card);
                    }

                    Console.WriteLine("Play an order from your hand or select a move");

                    Console.WriteLine("Hit arrowkey for direction to move or space to protect for {0}: ", player.Name);
                    var playerOrder = new Orders();

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerOrder = Orders.MoveUp;
                            break;
                        case ConsoleKey.DownArrow:
                            playerOrder = Orders.MoveDown;
                            break;
                        case ConsoleKey.LeftArrow:
                            playerOrder = Orders.MoveLeft;
                            break;
                        case ConsoleKey.RightArrow:
                            playerOrder = Orders.MoveRigth;
                            break;
                        case ConsoleKey.Spacebar:
                            playerOrder = Orders.Protect;
                            break;
                        case ConsoleKey.D0:
                            playerOrder = Orders.DobbelMove;
                            break;
                    }

                    //Assign player Order
                    player.PlayerOrder = playerOrder;

                    Console.WriteLine(player.Name + " has the order " + player.PlayerOrder);
                }
                if (player.State == PlayerState.Down)
                {
                    player.State = PlayerState.Up;
                    player.PlayerOrder = Orders.NoOrder;
                    Console.WriteLine("{0} was down and is now up, can take no order this turn");
                    
                }
                Console.WriteLine("----------------------------");
            }
    }

        public void ExecuteOrders(Match match)
        {
            foreach (Player player in match.PlayersInMatch(match))
            {
                if (player.PlayerOrder == Orders.MoveUp)
                {
                    ExecuteMoveUp(player);
                }
                if (player.PlayerOrder == Orders.MoveDown)
                {
                    ExecuteMoveDown(player);
                }
                if (player.PlayerOrder == Orders.MoveLeft)
                {
                    executeMoveLeft(player);
                }
                if (player.PlayerOrder == Orders.MoveRigth)
                {
                    executeMoveRigth(player);
                }
                if (player.PlayerOrder == Orders.Protect)
                {
                    executeProtection(player);
                }
                if (player.PlayerOrder == Orders.DobbelMove)
                {
                    ExecuteDobbleMove(player);
                }
            }
        }

        public enum Orders
        {
            NoOrder,
            DirtyProtection,
            DobbelMove,
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRigth,
            Protect
        }

        private void ExecuteMoveUp(Player playerToTakeAction)
        {
            Console.WriteLine("EXECUTE: {0} trying to go up", playerToTakeAction.Name);
            playerToTakeAction.Position.Y--;
        }

        private void ExecuteMoveDown(Player playerToTakeAction)
        {
            Console.WriteLine("EXECUTE{0} trying to go down", playerToTakeAction.Name);
            playerToTakeAction.Position.Y++;
        }

        private void executeMoveLeft(Player playerToTakeAction)
        {
            Console.WriteLine("EXECUTE: {0} trying to go left", playerToTakeAction.Name);
            playerToTakeAction.Position.X--;
        }

        private void executeMoveRigth(Player playerToTakeAction)
        {
            Console.WriteLine("{0} trying to go Rigth", playerToTakeAction.Name);
            playerToTakeAction.Position.X++;
        }

        private void executeProtection(Player playerToTakeAction)
        {
            Console.WriteLine("EXECUTE: {0} protecting", playerToTakeAction.Name);
        }

        public void ExecuteDobbleMove(Player player)
        {
            Console.WriteLine("");
            Console.WriteLine("EXECUTE: Double move");


            for (int i = 0; i < 2; i++ )
            {
                Console.WriteLine("Hit arrow key for move");
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        ExecuteMoveUp(player);
                        break;
                    case ConsoleKey.DownArrow:
                        ExecuteMoveDown(player);
                        break;
                    case ConsoleKey.LeftArrow:
                        executeMoveLeft(player);
                        break;
                    case ConsoleKey.RightArrow:
                        executeMoveRigth(player);
                        break;
                }
            }
            //Execute orer
        }
    
    }
}
