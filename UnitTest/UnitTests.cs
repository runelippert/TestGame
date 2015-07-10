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
            Rolls roll = new Rolls();
            roll.rollForEngagement(new Coordinate(1, 1), thisMatch);

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


        //TO DO - write move tests

        [Theory]
        [InlineData(BasicActions.Actions.up, 1, 0)]
        [InlineData(BasicActions.Actions.down, 1,2)]
        [InlineData(BasicActions.Actions.left, 0, 1 )]
        [InlineData(BasicActions.Actions.rigth, 2, 1)]
        [InlineData(BasicActions.Actions.protect, 1, 1)]
        public void takeActionTest(BasicActions.Actions action, int end_x, int end_y )
        {
            //Arrange
            Player alfred = new Player(){ name="Alfred", position=new Coordinate(1,1)};

            //act
            BasicActions.takeAction(alfred, action);

            //Assert
            Assert.Equal(end_x, alfred.position.x);
            Assert.Equal(end_y, alfred.position.y);
        }

    }
}