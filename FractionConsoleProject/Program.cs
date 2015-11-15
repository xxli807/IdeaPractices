using AddSubtractMultiplyDivideFractions;
using AddSubtractMultiplyDivideFractions.Service;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionConsoleProject
{
    class Program
    {        
        private static IOperation _operation;
        private static Fraction firstFraction;
        private static Fraction secondFraction; 
        private static string operation;

        static void Main(string[] args)
        {
            while (true)
            {
                //register all the interface
                IOC.InitDI();
                _operation = IOC.GetStandardKernel().Get<IOperation>();

                //get firstInput
                GetFirstInput();

                GetSecondInput();

                while(Calculation())
                {
                    GetSecondInput();                 
                }

                //exist
                Console.ReadKey();
            } 

        }


        public static void GetFirstInput()
        {
            Console.WriteLine("Please enter the Numerator");
            var numerator = Console.ReadLine();

            Console.WriteLine("Please enter the Denominator");
            var denominator = Console.ReadLine();

            //validation the input and then keep doing the same thing
            if (!_operation.ValidateNumeratorAndDenominator(numerator, denominator))
            {
                Console.WriteLine("Numerator and Denominator must in int format.Please check the input {0} and {1}.", numerator, denominator);
                Console.ReadKey();
                Environment.Exit(0);
            }

            firstFraction = new Fraction(int.Parse(numerator), int.Parse(denominator));            
        }


        public static void GetSecondInput()
        {
            Console.WriteLine("Please enter the Operation");
            var inputOperation = Console.ReadLine();
            if (!_operation.ValidatorOperator(inputOperation))
            {
                Console.WriteLine("Only +,-,*,/ operation are supported.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            operation = inputOperation;

            Console.WriteLine("Please enter the other Numerator");
            var numerator = Console.ReadLine();

            Console.WriteLine("Please enter the other Denominator");
            var denominator = Console.ReadLine();
            if (!_operation.ValidateNumeratorAndDenominator(numerator, denominator))
            {
                Console.WriteLine("Numerator and Denominator must in int format.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            secondFraction = new Fraction(int.Parse(numerator), int.Parse(denominator));
        }

        public static bool Calculation()
        {
            decimal result=0;
            switch (operation)
            {
                case "+":
                    result = _operation.AddFraction(firstFraction, secondFraction);
                    break;
                case "-":
                    result = _operation.SubtractFraction(firstFraction, secondFraction);
                    break;
                case "*":
                    result = _operation.MultipleFraction(firstFraction, secondFraction);
                    break;
                case "/":
                    result = _operation.DivideFraction(firstFraction, secondFraction);
                    break;

            }
            firstFraction = _operation.GetNewFraction();
            Console.WriteLine("new fraction is: "+ firstFraction.Numerator + "  " +firstFraction.Denominator);
            Console.WriteLine("result is: " + result.ToString("0.00"));
            return true;
        }



    }
}
