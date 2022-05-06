using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Circle: IArea
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {                
                radius = parseRadius(value);
            }
        }

        private double parseRadius(double value)
        {
            if (value <= 0)
                throw new Exception("Radius must be positive");

            return value;
        }

        public double Area()
        {            
            return Math.PI * Radius * Radius;
        }
    }
}
