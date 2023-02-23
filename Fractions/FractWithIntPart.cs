using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    public class FractionWithIntPart : Fraction
    {
        public int IntPart { get; private set; }


        public FractionWithIntPart(int intPart, int numerator, int denominator) : base(numerator, denominator)
        {
            IntPart = intPart;
            ConvertFraction();
        }
        public FractionWithIntPart(int numerator, int denominator) : base(numerator, denominator)
        {
            IntPart = 0;
            ConvertFraction();
        }
        public FractionWithIntPart(FractionWithIntPart fraction) : base(fraction)
        {
            IntPart = fraction.IntPart;
            ConvertFraction();
        }
        public FractionWithIntPart(Fraction fraction) : base(fraction)
        {
            ConvertFraction();
        }
        protected void ConvertFraction()
        {
            if (Numerator >= Denominator)
            {
                IntPart += (int)(Numerator / Denominator);
                Numerator %= Denominator;
            }
        }
        public static void ConvertFraction(FractionWithIntPart a)
        {
            if (a.Numerator >= a.Denominator)
            {
                a.IntPart += (a.Numerator / a.Denominator);
                a.Numerator %= a.Denominator;
            }
        }
        public FractionWithIntPart(int intPart) : this(intPart, 0, 1)
        {
        }
        public override string ToString() 
        {
            if (IntPart == 0)
            {
               return base.ToString();
            }
            else
            {
                return $"{IntPart} {base.ToString()}";
            }
        }
        public static FractionWithIntPart operator +(FractionWithIntPart a) => a;
        public static FractionWithIntPart operator -(FractionWithIntPart a) => new FractionWithIntPart(-a.IntPart, -a.Numerator, a.Denominator);
        public static FractionWithIntPart operator +(FractionWithIntPart a, FractionWithIntPart b) => new FractionWithIntPart(a.IntPart + b.IntPart, a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        public static FractionWithIntPart operator +(FractionWithIntPart a, int b) => new FractionWithIntPart(a.IntPart + b, a.Numerator, a.Denominator);
        public static FractionWithIntPart operator -(FractionWithIntPart a, FractionWithIntPart b) => a + (-b);
        public static FractionWithIntPart operator -(FractionWithIntPart a, int b)
        {
            var temp = new FractionWithIntPart(b - a.Denominator / a.Denominator, a.Denominator, a.Denominator);
            return a - temp;

        }
        public static FractionWithIntPart operator *(FractionWithIntPart a, FractionWithIntPart b)
        {
            var den = a.Denominator * b.Denominator;

            var num = (a.Numerator + (a.IntPart * a.Denominator)) * (b.Numerator + (b.IntPart * b.Denominator));

            var product = new FractionWithIntPart(0, num, den);

            ConvertFraction(product);

            return product;

        }
        public static FractionWithIntPart operator /(FractionWithIntPart a, FractionWithIntPart b)
        {
            var num = (a.Numerator + (a.IntPart * a.Denominator)) * b.Denominator;

            var den = (b.Numerator + (b.IntPart * b.Denominator)) * a.Denominator;

            var quotient = new FractionWithIntPart(0, num, den);

            ConvertFraction(quotient);  

            return quotient;
        }
    }
}
    
