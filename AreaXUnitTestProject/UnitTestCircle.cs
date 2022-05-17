using ClassLibrary1;
using System;
using Xunit;

namespace AreaXUnitTestProject
{
    public class UnitTestCircle
    {
        [Fact]
        public void TestCircle()
        {
            Exception exc = Assert.Throws<Exception>(() => new Circle() { Radius = -1 } );
            string expected = "Radius must be positive";
            string actual = exc.Message;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAreaCircle()
        {
            IArea circle = new Circle() { Radius = 3 };
            double actual = Math.Round(circle.Area(), 2);
            double expected = 28.27;
            Assert.Equal(expected, actual);
        }
    }
}
