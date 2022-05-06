using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Triangle : IArea
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        /// <summary>
        /// Create an equilateral triangle
        /// </summary>
        /// <param name="side"></param>
        public Triangle(double side) : this(side, side, side) { }

        /// <summary>
        /// Create triangle on three sides
        /// </summary>
        /// <param name="a">side one</param>
        /// <param name="b">side two</param>
        /// <param name="c">side three</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new Exception("The side of the triangle must be positive.");
            }
            else
            {
                if (a > b && a > c && a >= b + c
                    || b > a && b > c && b >= a + c
                    || c >= a + b)
                {
                    throw new Exception("The larger side of the triangle must be less than the sum of the other two sides.");
                }
                else
                {
                    SideA = a;
                    SideB = b;
                    SideC = c;
                }
            }
        }
        
        public double Perimeter
        {
            get
            {
                return SideA + SideB + SideC;
            }
        }

        public double Area()
        {
            // вычисление по формуле Герона

            double pp = Perimeter / 2;
            double square = Math.Sqrt(pp * (pp - SideA) * (pp - SideB) * (pp - SideC));

            if (square == double.NaN || square == double.PositiveInfinity)
                throw new Exception("Can't calculate the area of the triangle");

            return square;
        }

        public bool IsRight()
        {
            // вычисление по формуле Пифагора
            bool result = false;            

            double sideA = Math.Pow(SideA, 2);
            double sideB = Math.Pow(SideB, 2);
            double sideC = Math.Pow(SideC, 2);

            if (SideA > SideB && SideA > SideC)
            {
                result = sideA == (sideB + sideC);
            }
            else if (SideB > SideA && SideB > SideC)
            {
                result = sideB == (sideA + sideC);
            }
            else
            {
                result = sideC == (sideA + sideB);
            }

            return result;
        }
    }
}
