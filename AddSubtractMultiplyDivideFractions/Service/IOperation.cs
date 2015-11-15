using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSubtractMultiplyDivideFractions.Service
{

    public interface IOperation
    {
        bool ValidateNumeratorAndDenominator(string numberator, string denominator);
        bool ValidatorOperator(string inputOperator);
        Fraction GetNewFraction();
        decimal AddFraction(Fraction firstFraction, Fraction secondFraction);
        decimal SubtractFraction(Fraction firstFraction, Fraction secondFraction);
        decimal MultipleFraction(Fraction firstFraction, Fraction secondFraction);
        decimal DivideFraction(Fraction firstFraction, Fraction secondFraction);

    }
}
