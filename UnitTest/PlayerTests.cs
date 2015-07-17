using System.Collections.Generic;
using Classes;
using Xunit;

namespace UnitTest
{
    public class PlayerTests
    {
        //Write give Order Test

        [Theory]
        [InlineData(Player.Orders.MoveUp, 1, 0)]
        [InlineData(Player.Orders.MoveDown, 1, 2)]
        [InlineData(Player.Orders.MoveLeft, 0, 1)]
        [InlineData(Player.Orders.MoveRigth, 2, 1)]
        [InlineData(Player.Orders.Protect, 1, 1)]
        public void ExecuteMoveOrderTest(Player.Orders order, int end_x, int end_y)
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            Match thisMatch = new Match()
            {
                HomeTeam = firsteTeam,
                AwayTeam = secondTeam
            };

            Player alfred = new Player() { Name = "Alfred", Position = new Coordinate(1, 1), PlayerOrder = order, Team = firsteTeam };

            firsteTeam.PlayersOnTeam.Add(alfred);    
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 1, Name = "Alpha", Position = new Coordinate(2, 1), Team = firsteTeam });
            firsteTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 2, Name = "Beta", Position = new Coordinate(1, 1), Team = firsteTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 10, Name = "Egon", Position = new Coordinate(1, 1), Team = secondTeam });
            secondTeam.PlayersOnTeam.Add(new Player() { ShirtNumber = 11, Name = "Benny", Position = new Coordinate(1, 1), Team = secondTeam });

            Player player = new Player();

            //act
            player.ExecuteOrders(thisMatch);            

            //Assert
            Assert.Equal(end_x, alfred.Position.X);
            Assert.Equal(end_y, alfred.Position.Y);
        }
    }
}
