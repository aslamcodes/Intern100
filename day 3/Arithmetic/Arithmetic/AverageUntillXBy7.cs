using System;


namespace Arithmetic
{
    internal class AverageUntillXBy7
    {
        //Find the avearage of all the numbers
        //that are divisible by 7 until the user specified number.
        //
        //Take input until the user enters a negative number
        public int num;
        public AverageUntillXBy7() {
            while (true)
            {
                Console.WriteLine("Enter your number");
                this.num = Convert.ToInt32(Console.ReadLine());

                if (this.num < 0)
                {
                    Console.WriteLine("Ending");
                    break;
                }

                int sum = 0;

                for (int i = 7; i < this.num; i += 7) {
                    sum += i;
                }

                Console.WriteLine($"Sum = {sum}");


            }
        }
    }
}
