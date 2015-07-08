using Xunit;
using Classes;
using System.Collections.Generic;

namespace UnitTests
{
    public class Class1
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
        public void falingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }


        int Add(int x, int y)
        {
            return x + y;
        }


    }
}