using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractMultiplyDivideFractions.Service
{
    public class OperationService : IOperation
    {
        public Fraction newFraction = new Fraction();

        public Fraction GetNewFraction()
        {
            return this.newFraction;
        }

        public bool ValidateNumeratorAndDenominator(string numberator, string denominator)
        {
            int number = 0;
            return int.TryParse(numberator, out number) && int.TryParse(denominator, out number) && denominator !="0";
        }


        public bool ValidatorOperator(string inputOperator)
        {
            if (inputOperator == "+" || inputOperator == "-" || inputOperator == "/" || inputOperator == "*") { 
                return true;
            }

            return false;
        }



        public decimal AddFraction(Fraction firstFraction, Fraction secondFraction)
        {

            newFraction.Numerator = firstFraction.Numerator * secondFraction.Denominator + secondFraction.Numerator * firstFraction.Denominator;
            newFraction.Denominator = firstFraction.Denominator * secondFraction.Denominator;
             
            return Math.Round(Decimal.Divide(newFraction.Numerator, newFraction.Denominator), 2, MidpointRounding.AwayFromZero);

        }

        public decimal DivideFraction(Fraction firstFraction, Fraction secondFraction)
        {
            newFraction.Numerator = firstFraction.Numerator * secondFraction.Denominator;
            newFraction.Denominator = firstFraction.Denominator * secondFraction.Numerator;
              
            return Math.Round(Decimal.Divide(newFraction.Numerator, newFraction.Denominator), 2, MidpointRounding.AwayFromZero);
        }

        public decimal MultipleFraction(Fraction firstFraction, Fraction secondFraction)
        {
            newFraction.Numerator = firstFraction.Numerator * secondFraction.Numerator;
            newFraction.Denominator = firstFraction.Denominator * secondFraction.Denominator;
          
            return Math.Round(Decimal.Divide(newFraction.Numerator, newFraction.Denominator), 2, MidpointRounding.AwayFromZero);
        }

        public decimal SubtractFraction(Fraction firstFraction, Fraction secondFraction)
        {
            newFraction.Numerator = firstFraction.Numerator * secondFraction.Denominator - secondFraction.Numerator * firstFraction.Denominator;
            newFraction.Denominator = firstFraction.Denominator * secondFraction.Denominator;
       
            return Math.Round(Decimal.Divide(newFraction.Numerator,newFraction.Denominator), 2, MidpointRounding.AwayFromZero);
        }
    }
}
