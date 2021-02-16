using System;

namespace Calculator.Logic
{
    public class Operations
    {
        /// <summary>
        /// Adds two doubles
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Double</returns>
        public static double AddNumbers(double a, double b)
        {
            double result = a + b;

            return Math.Round(result, 7);
        }

        public static double SubtractNumbers(double a, double b)
        {
            double result = a - b;

            return Math.Round(result, 7);
        }

        public static double MultiplyNumbers(double a, double b)
        {
            double result = a * b;

            return Math.Round(result, 7);
        }

        public static double DivideNumbers(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Maths Error");
            }
            double result = a / b;

            return Math.Round(result, 7);
        }

        public static int NegateInt(int a)
        {
            int result = a * -1;

            return result;
        }

        public static double NegateDouble(double a)
        {
            double result = a * -1;

            return result;
        }

        public static int UpdateInt(int a, int b)
        {
            int result;
            if (a < 0)
            {
                result = (a * 10) - b;
            }
            else
            {
                result = (a * 10) + b;
            }
            return result;
        }

        public static double UpdateDouble(double a, int b, int decimalPosition)
        {
            double result;
            if (a < 0)
            {
                result = a - (b / Math.Pow(10, decimalPosition));
            }
            else
            {
                result = a + (b / Math.Pow(10, decimalPosition));
            }

            return result;
        }
    }
}
