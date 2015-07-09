﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Match
    {
            //definition of home Team and away team
            public Team homeTeam { get; set; }

            public Team awayTeam { get; set; }

            public List<Player> playersInMatch(Match match)
            {
                List<Player> playersInMatch = new List<Player>();

                foreach (Player x in match.homeTeam.playersOnTeam)
                {
                    playersInMatch.Add(x);
                }

                foreach (Player x in match.awayTeam.playersOnTeam)
                {
                    playersInMatch.Add(x);
                }

                return playersInMatch;
            }

            public List<Player> getPlayersAtCoordinate(Coordinate coordinate, Match match)
            {
                List<Player> playersAtCoordinate = new List<Player> { };

                //Check all players coordinate
                foreach (Player somePlayer in match.playersInMatch(match))
                {
                    if (somePlayer.position.x == coordinate.x)
                        if (somePlayer.position.y == coordinate.y)
                        {
                            playersAtCoordinate.Add(somePlayer);
                        }
                };

                return playersAtCoordinate;
            }

            public Match setupMatch()
            {
                Team homeTeam = new Team() { TeamName = "The greeks" };
                Team awayTeam = new Team() { TeamName = "Olsen banden" };

                Match thisMatch = new Match()
                {
                    homeTeam = homeTeam,
                    awayTeam = awayTeam
                };

                Console.WriteLine("--PRESENTING THE HOME TEAM: {0}", homeTeam.TeamName);
                Console.WriteLine("--PRESENTING THE AWAY TEAM: {0}", awayTeam.TeamName);

                Player players = new Player();

                homeTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(2, 1), team = homeTeam });
                homeTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 2), team = homeTeam });
                awayTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1), team = awayTeam });
                awayTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(2, 2), team = awayTeam });

                foreach(Player player in homeTeam.playersOnTeam)
                {
                    Console.WriteLine("For {0} first player is #{1} {2}", homeTeam.TeamName, player.shirtNumber, player.name);
                }

                foreach(Player player in awayTeam.playersOnTeam)
                {
                    Console.WriteLine("For {0} first player is #{1} {2}", awayTeam.TeamName, player.shirtNumber, player.name);

                }
                
                return thisMatch;
            }
            

    }
}
