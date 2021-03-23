using System;

namespace PS1
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            string output;
            while (true)
            {

                Console.WriteLine("Enter integer:");
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid value!");
                    continue;
                }
                output = "";
                if (value % 3 == 0)
                {
                    output += "fizz";
                }
                if (value % 5 == 0)
                {
                    output += "buzz";
                }
                if (output == "") output += value;
                Console.WriteLine(output);
            }
        }
    }
}
