using System.Collections.Generic;
using Classes;
using Xunit;

namespace UnitTest
{
    public class UnitTests
    {
        [Fact]
        public void GetPlayersAtCoordinateTest()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(2, 1), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(1, 1), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(1, 1), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(1, 1), Team = secondTeam });


            //Act
            var playersToFind = thisMatch.GetPlayersAtCoordinate(new Coordinate(1, 1), thisMatch);
            
            //Assert
            Assert.NotEmpty(playersToFind);
            Assert.Equal(3, playersToFind.Count);
            Assert.Equal("Beta", playersToFind[0].Name);
            Assert.Equal("The greeks", playersToFind[0].Team.TeamName);
            Assert.Equal("Egon", playersToFind[1].Name);
            Assert.Equal("Olsen banden", playersToFind[1].Team.TeamName);
            Assert.Equal("Benny", playersToFind[2].Name);
            Assert.Equal("Olsen banden", playersToFind[2].Team.TeamName);




        }

        [Fact]
        public void rollForEngagementTest()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };
            Ball ball = new Ball();

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam,
                MatchBall = ball
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(2, 1), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(1, 1), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(1, 1), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(1, 1), Team = secondTeam });

            //Act
            Rolls roll = new Rolls();
            roll.RollForEngagement(new Coordinate(1, 1), thisMatch);

            //Assert
            

        }


        [Theory]
        [InlineData(6,6, Rolls.ResultOfEngagement.Tie)]
        [InlineData(6, 1, Rolls.ResultOfEngagement.HomeTeam)]
        [InlineData(1, 3, Rolls.ResultOfEngagement.AwayTeam)]
        public void findWinnerTest(int a, int b, Rolls.ResultOfEngagement expectedResult)
        {
            Rolls roll = new Rolls();
            Match match = new Match
            {
                HomeTeam = new Team() { TeamName = "The greeks" },
                AwayTeam = new Team() { TeamName = "Olsen banden" }
            };

           //ACT
            var result = roll.FindWinner(match, a, b);

            //ASSERT
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CompairePlayerPostionTestNoCoordinate()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(1, 1), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(2, 2), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(3, 3), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(4, 4), Team = secondTeam });


            //Act
            List<Coordinate> result = thisMatch.CompairePlayersCoordinates(thisMatch);

            //Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void CompairePlayerPostionTestPlayersFromSameTeamOnACoordinate()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(1, 2), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(1, 2), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(3, 3), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(4, 4), Team = secondTeam });


            //Act
            List<Coordinate> result = thisMatch.CompairePlayersCoordinates(thisMatch);

            //Assert
            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void compairePlayerPostionTest1Coordinate()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(1, 1), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(3, 2), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(5, 2), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(6, 2), Team = secondTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 3, Name = "Gamma", Position = new Coordinate(3, 2), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 13, Name = "Kjeld", Position = new Coordinate(3, 2), Team = secondTeam });


            //Act
            List<Coordinate> result = thisMatch.CompairePlayersCoordinates(thisMatch);

            //Assert
            Assert.Equal(new Coordinate(3, 2), result[0]);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void compairePlayerPostionTest2Coordinate()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(5, 5), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(3, 2), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(5, 5), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(3, 2), Team = secondTeam });


            //Act
            List<Coordinate> result = thisMatch.CompairePlayersCoordinates(thisMatch);

            //Assert
            Assert.Equal(new Coordinate(5, 5), result[0]);
            Assert.Equal(new Coordinate(3, 2), result[1]);
            Assert.Equal(2, result.Count);
        }

        //TO DO write effect of engagement test
        [Theory]
        [InlineData(Rolls.ResultOfEngagement.HomeTeam, "Olsen banden")]
        [InlineData(Rolls.ResultOfEngagement.AwayTeam, "The greeks")]
        public void effectOfEngagementTest(Rolls.ResultOfEngagement engagementResult, string loserTeam)
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            //Setup players at an engagement
            Rolls roll = new Rolls();
            List<Player> homeTeamPlayersAtCoordinate = new List<Player>();
            List<Player> awayTeamPlayersAtCoordinate = new List<Player>();

            homeTeamPlayersAtCoordinate.Add(new Player() { Name="Aplha", State = Player.PlayerState.Up, Team = firsteTeam});
            homeTeamPlayersAtCoordinate.Add(new Player() { Name="Beta", State = Player.PlayerState.Up, Team = firsteTeam});
            awayTeamPlayersAtCoordinate.Add(new Player() { Name = "Ringo", State = Player.PlayerState.Up, Team = secondTeam});
            awayTeamPlayersAtCoordinate.Add(new Player() { Name = "John", State = Player.PlayerState.Up, Team = secondTeam});

            //Act          
            var result = roll.EffectOfEngangement(engagementResult, homeTeamPlayersAtCoordinate, awayTeamPlayersAtCoordinate);

            //Assert
            Assert.Equal(Player.PlayerState.Down, result.State);
            Assert.Equal(loserTeam, result.Team.TeamName);
        }



    }
}