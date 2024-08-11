namespace UnitTest
{
    public class UnitTest1
    {
        // xUnit.net includes support for two different major types of unit tests: facts and theories
        //Facts are tests which are always true. They test invariant conditions.
        //Theories are tests which are only true for a particular set of data.

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }
        [Fact]
        public void FailingTest()
        {
            Assert.Equal(1, Add(1, 1));
        }
        int Add( int x, int y )
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void FirstTheory( int value )
        {
            Assert.True(IsOdd(value));

        }
        bool IsOdd( int value )
        {
            return value % 2 == 1;
        }

    }
}