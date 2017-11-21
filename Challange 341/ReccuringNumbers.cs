using System;

namespace Challenge_341
{
    class RecurringNumbers
    {
        private static string number;


        static void Main(string[] args)
        {
            number = Console.ReadLine();

            for (int i = 0; i < number.Length / 2; i++)
                for(int j = 2; j < number.Length / 2; j++) {
                    int matches = NumOfMatches(number.Substring(i, j));
                    if (matches != 0)
                        Console.Write(number.Substring(i, j) + ":" + matches + " ");
                }

            Console.ReadKey();

        }

        static int NumOfMatches(string stringOfDigits)
        {
            int numOfOccurences = 0;
            for (int i = 0; i <= number.Length - stringOfDigits.Length; i++) {
                if (number.Substring(i, stringOfDigits.Length) == stringOfDigits.ToString()) {
                    numOfOccurences++;
                }
            }
            if (numOfOccurences > 1)
                return numOfOccurences;
            else
                return 0;
        }


    }
    
}