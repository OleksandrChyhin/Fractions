using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class Fraction
    {
        public int Numerator { get; protected set; }
        public int Denominator { get; protected set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("you can't divide by zero", nameof(denominator));
            }
            if (denominator < 0)
            {
                throw new ArgumentException("denominator can't be less than zero", nameof(denominator));
            }
            Numerator = numerator;
            Denominator = denominator;

        }
        public Fraction(Fraction fraction) : this(fraction.Numerator, fraction.Denominator)
        {

        }
        protected static void ReduceTheFraction(Fraction a)
        {
            int FindGDC(Fraction a)
            {
                int num = a.Numerator;
                int den = a.Denominator;
                while (den != 0)
                {
                    int remainder = num % den;
                    num = den;
                    den = remainder;
                }
                return num;
            }
            int GCD = FindGDC(a);
            while (GCD != 1)
            {
                a.Numerator /= GCD;
                a.Denominator /= GCD;
                GCD = FindGDC(a);
            }
        }
        public override string ToString() => $"{Numerator}/{Denominator}";

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.Numerator, a.Denominator);
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction sum = new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
            ReduceTheFraction(sum);
            return sum;
        }


        public static Fraction operator +(Fraction a, int b)
        {
            var temp = new Fraction(a.Denominator * b, a.Denominator);
            var sum = a + temp;
            ReduceTheFraction(sum);
            return sum;
        }
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator -(Fraction a, int b)
        {
            var temp = new Fraction(a.Denominator * b, a.Denominator);
            return a - temp;
        }

        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static Fraction operator *(Fraction a, int b)
        {
            var temp = new Fraction(a.Denominator * b, a.Denominator);
            return a * temp;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            var num = a.Numerator * b.Denominator;
            var den = a.Denominator * b.Numerator;
            if (den < 0)
            {
                num *= -1;
                den *= -1;
            }
            return new Fraction(num, den);
        }

        public static Fraction operator /(Fraction a, int b)
        {
            var temp = new Fraction(a.Denominator * b, a.Denominator);
            return a / temp;
        }
    }
}


