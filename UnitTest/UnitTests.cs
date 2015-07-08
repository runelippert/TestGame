using Xunit;
using Classes;
using System.Collections.Generic;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void getPlayersAtCoordinateTest()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                homeTeam = firsteTeam,
                awayTeam = secondTeam
            };

            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(2, 1), team = firsteTeam });
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 1), team = firsteTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1), team = secondTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(1, 1), team = secondTeam });


            //Act
            var playersToFind = thisMatch.getPlayersAtCoordinate(new Coordinate(1, 1), thisMatch);
            
            //Assert
            Assert.NotEmpty(playersToFind);
            Assert.Equal(3, playersToFind.Count);
            Assert.Equal("Beta", playersToFind[0].name);
            Assert.Equal("The greeks", playersToFind[0].team.TeamName);
            Assert.Equal("Egon", playersToFind[1].name);
            Assert.Equal("Olsen banden", playersToFind[1].team.TeamName);
            Assert.Equal("Benny", playersToFind[2].name);
            Assert.Equal("Olsen banden", playersToFind[2].team.TeamName);




        }

        [Fact]
        public void rollForEngagementTest()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                homeTeam = firsteTeam,
                awayTeam = secondTeam
            };

            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 1, name = "Alpha", position = new Coordinate(2, 1), team = firsteTeam });
            firsteTeam.playersOnTeam.Add(new Player() { shirtNumber = 2, name = "Beta", position = new Coordinate(1, 1), team = firsteTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 10, name = "Egon", position = new Coordinate(1, 1), team = secondTeam });
            secondTeam.playersOnTeam.Add(new Player() { shirtNumber = 11, name = "Benny", position = new Coordinate(1, 1), team = secondTeam });

            //Act
            thisMatch.rollForEngagement(new Coordinate(1, 1), thisMatch);

            //Assert
            //TO DO roll for engagement needs to be updated to return a value or a string. 

        }


        [Theory]
        [InlineData(6,6, "its a tie")]
        [InlineData(6, 1, "The greeks is the winner")]
        [InlineData(1, 3, "Olsen banden is the winner")]
        public void findWinnerTest(int a, int b, string expectedResult)
        {
            Rolls roll = new Rolls();

            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

           //ACT
            var result = roll.findWinner(firsteTeam, a, secondTeam, b);

            //ASSERT
            Assert.Equal(expectedResult, result);
        }





    }
}