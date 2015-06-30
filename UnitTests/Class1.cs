
using Xunit;

namespace UnitTests
{
    public class Class1
    {
        [Fact]
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
