namespace CountRepeatingDigits
{
    internal class Program
    {
        
        static int countNumbersWithRepeating(int[] array, bool omitSingleDigit = true) {
            int count = 0;


     
            for (int i = 0; i < array.Length; i++)
            {
                string num = array[i].ToString();
                if (omitSingleDigit && num.Length == 1) {
                    continue;
                }
                char prev = num[0];
           
                bool flag = true;
                for (int j = 1; j < num.Length; j++)
                {
                    if (prev != num[j]) {
                        flag = false; break;
                    } 

                    prev = num[j];
                }

                if (flag)
                {
                    count++;
                }
                
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] arr = { 111, 222, 333, 1, 19, 0, 12 };
            Console.WriteLine(countNumbersWithRepeating(arr, false));

        }
    }
}
