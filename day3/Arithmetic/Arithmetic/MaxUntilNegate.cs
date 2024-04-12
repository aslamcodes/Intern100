using System;


namespace Arithmetic
{
    public class MaxUntilNegate
    {
        public int a;
        public int b;
        
        public MaxUntilNegate() {
            // Create an application
            // that will find the greatest of the given numbers.
            // Take input until the user enters a negative number
            Console.WriteLine("This program works until you give a negative number");

            while (true) {
                Console.WriteLine("Enter first value: ");
                this.a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter second value: ");
                this.b = Convert.ToInt32(Console.ReadLine());

                if(!(this.a >= 0) || !(this.b >= 0))
                {
                    Console.WriteLine("Ending");
                    break;
                }

                Console.WriteLine($"Max - {Math.Max(this.a, this.b)}");
            }
        }
    }
}
