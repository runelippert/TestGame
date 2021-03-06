﻿using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace Classes
{
    public class Match
    {
            //definition of home Team and away team
            public Team HomeTeam { get; set; }
            public Team AwayTeam { get; set; }
            public Ball MatchBall { get; set; }
            

            public List<Player> PlayersInMatch(Match match)
            {
                //Add all HomeTeam players to Players In Match List
                List<Player> playersInMatch = match.HomeTeam.PlayersOnTeam.ToList();

                //Add all away team players to list.
                playersInMatch.AddRange(match.AwayTeam.PlayersOnTeam);

                return playersInMatch;
            }

            public List<Player> GetPlayersAtCoordinate(Coordinate coordinate, Match match)
            {
                List<Player> playersAtCoordinate = new List<Player> { };

                //Check all players coordinate
                foreach (Player somePlayer in match.PlayersInMatch(match))
                {
                    if (somePlayer.Position.X == coordinate.X)
                        if (somePlayer.Position.Y == coordinate.Y)
                        {
                            playersAtCoordinate.Add(somePlayer);
                        }
                }

                return playersAtCoordinate;
            }

            public Match SetupMatch()
            {
                Team homeTeam = new Team() { TeamName = "The greeks" };
                Team awayTeam = new Team() { TeamName = "Olsen banden" };
                Ball ball = new Ball() {};

                Match thisMatch = new Match()
                {
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    MatchBall = ball
                };

                homeTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(1, 1), Team = homeTeam });
                homeTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(1, 3), Team = homeTeam });
                homeTeam.PlayersOnTeam.Add(new Player() {ShirtNumber = 3, Name = "Gamma", Position = new Coordinate(1,3), Team = homeTeam});
                awayTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(1, 5), Team = awayTeam });
                awayTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(1, 5), Team = awayTeam });
                awayTeam.PlayersOnTeam.Add(new Player() {ShirtNumber = 13, Name = "Kjeld", Position = new Coordinate(1,3), Team = awayTeam});

                Console.WriteLine("--PRESENTING THE HOME TEAM: {0}", homeTeam.TeamName);
                foreach (Player player in homeTeam.PlayersOnTeam)
                {
                    Console.WriteLine("For {0} first player is #{1} {2}", homeTeam.TeamName, player.ShirtNumber, player.Name);
                }

                Console.WriteLine("--PRESENTING THE AWAY TEAM: {0}", awayTeam.TeamName);

                foreach(Player player in awayTeam.PlayersOnTeam)
                {
                    Console.WriteLine("For {0} first player is #{1} {2}", awayTeam.TeamName, player.ShirtNumber, player.Name);

                }

                thisMatch.MatchBall.PlayerWithBall = homeTeam.PlayersOnTeam[0];

                Console.WriteLine("{0} startes with the ball", homeTeam.PlayersOnTeam[0]);
                
                return thisMatch;
            }

        //GetPlayers on homeTeam
        //Add position to a list of coordinates that has players from the home team
        //GetPlayers on AwayTeam
        //Add positon to a list of coordinates that has players from away team.
        //Compaire the 2 lists to find coordinates with conflicts 
        public List<Coordinate> CompairePlayersCoordinates(Match match)
        {
            List<Coordinate> result = new List<Coordinate>();

            List<Coordinate> awayTeamCoordinates = new List<Coordinate>();

            List<Coordinate> homeTeamCoordinates = match.HomeTeam.PlayersOnTeam.Select(player => player.Position).ToList();

            IEnumerable<Coordinate> homeTeamCoordinatesNoDublicates = homeTeamCoordinates.DistinctBy(x => x.X).DistinctBy(y => y.Y);

            foreach(Player player in match.AwayTeam.PlayersOnTeam)
            {
                awayTeamCoordinates.Add(player.Position);
            }

            //Compaire list
            result.AddRange(homeTeamCoordinatesNoDublicates.Where(coordinate => awayTeamCoordinates.Contains(coordinate)));

            //Remove dublicates
            return result;
        }


    }
}
