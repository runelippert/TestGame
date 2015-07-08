using Xunit;
using Classes;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
        public void getPlayersAtCoordinate()
        {
            //Arrange
            Team firsteTeam = new Team() { TeamName = "The greeks" };
            Team secondTeam = new Team() { TeamName = "Olsen banden" };

            //Act

            //Assert
        }
        public void passingTest()
        {
            Assert.Equal(4, Add(2, 2));
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