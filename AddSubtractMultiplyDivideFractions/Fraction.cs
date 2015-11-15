using AddSubtractMultiplyDivideFractions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractMultiplyDivideFractions
{
    



    public class Fraction
    {
         
        private int numberator;
        private int denominator;
       
        public Fraction(int numerator, int denominator)
        {
            this.numberator = numerator;
            this.denominator = denominator;
        }

        public Fraction()
        {
        }

        public int Numerator
        {
            get { return this.numberator; }
            set { numberator = value; }
        }

        public int Denominator
        {
            get { return this.denominator; }
            set { this.denominator = value; }
        }

       
         
    }
}
