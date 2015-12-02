using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatore
{

    /// <summary>
    /// using two stack to save the digits and operators separately
    /// </summary>
    class Program
    {
        private static string userInput = "";
        private static Stack stack = new Stack();
        private static Stack revsStack = new Stack(); 

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter all the numbers and operators in one time.");
            userInput = Console.ReadLine();
            //validate...the input

        }

         
        public static void ParseInput()
        {
            var inputChars = userInput.ToCharArray();
            string lastElem = "";

            for (var i = 0; i < inputChars.Length; i++)
            {
                if (char.IsDigit(inputChars[i]))
                {

                }
            }



        }


    }

   
}













