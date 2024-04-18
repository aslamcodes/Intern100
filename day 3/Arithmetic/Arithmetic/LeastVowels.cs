using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    internal class LeastVowels
    {
        //Take a string from user the words seperated by comma(","). 
        //seperate the words and
        //
        //find the words
        //          with the least number of
        //                          repeating vowels.
        //
        //print the count and the word.
        //If there is a tie then print all the words that tie for the least
        
        public string InputString {  get; set; }
        public LeastVowels()
        {
            this.FindWordsWithLeastVowels();
        }

        private void FindWordsWithLeastVowels()
        {
            Console.WriteLine("Enter the string");
            InputString = Console.ReadLine();
            string[] words = InputString.Split(',');
            int leastVowelCount = int.MaxValue;
            foreach (string word in words)
            {
                leastVowelCount = Math.Min(leastVowelCount, CountRepeatedVowels(word));
            }

            foreach (string word in words) { 
                if(CountRepeatedVowels(word) == leastVowelCount)
                {
                    Console.WriteLine(word);
                }
            }



        }

        private static int CountRepeatedVowels(string word)
        {
            int maxCount = int.MinValue;
            char[] vowels = ['a', 'e', 'i', 'o', 'u'];
            word = word.ToLower();
            for (int i = 0; i < word.Length; i++) {
                if (vowels.Contains(word[i])) {
                    int count = 0;
                    for (int j = i + 1; j < word.Length; j++) {
                        if (vowels.Contains(word[j])) count++;
                    }
                    maxCount = Math.Max(maxCount, count);
                }
            }

            return maxCount;
        }

    }
}
