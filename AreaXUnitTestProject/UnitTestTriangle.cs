using ClassLibrary1;
using System;
using Xunit;

namespace AreaXUnitTestProject
{
    public class UnitTestTriangle
    {
        [Fact]
        public void TestTriangle()
        {
            Exception exc = Assert.Throws<Exception>(() => new Triangle(5, -4, 3));
            string expected = "The side of the triangle must be positive.";
            string actual = exc.Message;
            Assert.Equal(expected, actual);

            exc = Assert.Throws<Exception>(() => new Triangle(5, 1, 2));
            expected = "The larger side of the triangle must be less than the sum of the other two sides.";
            actual = exc.Message;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestAreaTriangle()
        {
            IArea triangle = new Triangle(5, 4, 3);
            double actual = triangle.Area();
            double expected = 6;
            Assert.Equal(expected, actual);

            triangle = new Triangle(6);
            actual = Math.Round(triangle.Area(), 2);
            expected = 15.59;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRightTriangle()
        {
            Triangle triangle = new Triangle(5, 4, 3);
            Assert.True(triangle.IsRight());

            triangle = new Triangle(5);
            Assert.False(triangle.IsRight());

            triangle = new Triangle(5, 3, 3);
            Assert.False(triangle.IsRight());
        }
    }
}
