namespace Day5Practice
{
    internal class Program
    {
        enum Weather
        {
            Hot,
            Cold,
            Winter,

        }

        void UnderstandingSequenceStatements()
        {
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
        }

        void UnderstandingSelctionStms()
        {
            bool havingFun = false;


            if (!havingFun)
            {
                Console.WriteLine("Weekend!");
            }
            else
            {
                Console.WriteLine("Backend");
            }
        }


        void UnderstandingSwitchStmts()
        {
            Weather status = Weather.Hot;

            switch (status)
            {
                case Weather.Hot:
                    Console.WriteLine("User drinks cofee");
                    break;
                case Weather.Cold:
                    Console.WriteLine("User eats Ice cream");
                    break;
                case Weather.Winter:
                    Console.WriteLine("User drinks tea");
                    break;
                default:
                    Console.WriteLine("Sleeps");
                    break;
            }

        }

        static void UnderstandingIterations()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Iteration {i + 1}");
            }
            int a = 5;

            while (a > 0)
            {
                Console.WriteLine($"While iteration: a = {a}");

                a--;
                if (a == 3)
                {
                    //break;
                    continue;
                }
            }

            do
            {
                Console.WriteLine($"Do While a = {a}"); a++;
            } while (a < 10);
        }

        public static void UnderstandingArrays()
        {
            int numbersWithRepeatedDigits = 0;
            int[] arr = { 12, 11, 19, 21 };
            for (int i = 0; i < arr.Length ; i++)
            {
              
            }
        } 
        static void Main(string[] args)
        {
            Program p = new();

            p.UnderstandingSequenceStatements();
            p.UnderstandingSelctionStms();
            p.UnderstandingSwitchStmts();
            UnderstandingIterations();
        }
    }
}
