using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TddKata1
{
    class StringCalculator
    {
        private List<ProcessValueAction> _numberStrageies;

        private delegate void ProcessValueAction(int newNumber, ref int aggregate, ref bool stopProcessing);

        public StringCalculator()
        {
            _numberStrageies = new List<ProcessValueAction>();
            _numberStrageies.Add(ThrowOnNegativeValues);
            _numberStrageies.Add(SkipNumbersLargerThan1000);
            _numberStrageies.Add(AggregateNewNumber);
        }

        private static void AggregateNewNumber(int newNumber, ref int aggregate, ref bool stopProcessing)
        {
            aggregate += newNumber;
        }

        private static void SkipNumbersLargerThan1000(int newNumber, ref int aggregate, ref bool stopProcessing)
        {
            if (newNumber > 1000)
                stopProcessing = true;
        }

        private static void ThrowOnNegativeValues(int newNumber, ref int aggregate, ref bool stopProcessing)
        {
            if (newNumber < 0)
            {
                throw new ArgumentOutOfRangeException("negatives not allowed");
            }
        }

        public int Add(string inputs)
        {
            CalculationExpressionParser parser = new CalculationExpressionParser();
            string[] delimiter = parser.Delimiters(inputs);
            string[] allSeparators = delimiter.Concat(new[]{"\n"}).ToArray();
            string[] strings = inputs.Split(allSeparators, StringSplitOptions.RemoveEmptyEntries);

            int temp = 0;
            int result = 0;
            foreach (string number in strings)
            {
                if(Int32.TryParse(number, out temp))
                {
                    bool stopProcessing = false;
                    foreach (ProcessValueAction numberStragey in _numberStrageies)
                    {
                        numberStragey(temp, ref result, ref stopProcessing);
                        if (stopProcessing)
                            break;
                    }    
                }
            }
            return result;
        }
    }
}
