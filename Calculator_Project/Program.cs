using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            float num1;
            float num2;
            float result;
            string aswer;

            Console.WriteLine("Welcome to Cowculator");
            Console.WriteLine("----------------------------");

            while (true)
            {

                Console.WriteLine("Please insert your first number ");

                if (!float.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Please insert your second number ");

                if (!float.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("What type of opration you would like to do?");
                Console.WriteLine("Press 'a' for addition, 's' for substraction, 'm' for multiplication, 'd' for division or 'q' to quit.");

                aswer = Console.ReadLine();
                if (aswer == "q")
                {
                    break;
                }
                if (aswer == "a")
                {
                    result = num1 + num2;
                }
                else if (aswer == "s")
                {
                    result = num1 - num2;
                }
                else if (aswer == "m")
                {
                    result = num1 * num2;
                }
                else if (aswer == "d")
                {
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("Please enter a valid operation or 'q' to quit!");
                    continue;
                }

                Console.WriteLine($"The result of your operation is {result}");


            }
            
            Console.WriteLine("Thank you for using the Cowculator. GoodBye!");
        }

    }
}
