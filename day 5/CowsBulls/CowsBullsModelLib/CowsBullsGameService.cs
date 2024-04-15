using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CowsBullsModelLib
{
    public class CowsBullsGameService
    {
        private int Score { get; set; } = 0;

        public int InitiateGame(string secret) {

            int cows = 0; int bulls = 0;
            HashSet<char> secretSet = secret.ToCharArray().ToHashSet();

            while (cows != 4)
            {
                cows = 0; bulls = 0;

                Console.Write("Enter your Guess: ");

                string guessed = Console.ReadLine() ?? String.Empty;


                for (int i = 0; i < guessed.Length; i++)
                {
                    if (guessed[i] == secret[i])
                    {
                        cows++;
                    }
                    else if (secretSet.Contains(guessed[i]))
                    {
                        bulls++;
                    }
                }

                Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");

                Score++;

            }

            return Score;

        }

        public int InitiateGameV2(string secret) {
            int steps = 0;

            int cows = 0;

            while(cows  != 4)
            {
                Console.WriteLine("Enter a guess");

                string guess = Console.ReadLine() ?? String.Empty;  

                List<char> secretList = [];
                List<char> guessList = [];

                cows = 0;
                int bulls = 0;
           
                for(int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == secret[i])
                    {
                        cows++;
                    }
                    else
                    {
                        secretList.Add(secret[i]);
                        guessList.Add(guess[i]);
                    }
                }

                for (int i = 0; i < secretList.Count; i++) {
                    if (guessList.Contains(secretList[i]))
                    {
                        bulls++;
                        guessList.Remove(secretList[i]);
                    }
                }

                Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");
               
                steps++;
            }

            return steps;
        }

        

        public int StartGame(Player[] players, string secret) {
            foreach (Player p in players) {
                Console.WriteLine($"{p.Name}'s turn!");
                p.MyScore = InitiateGameV2(secret);
                Console.Clear();
            }

            int winIdx = 0;
            int highScore = int.MaxValue;

            for(int i = 0; i < players.Length; i++)
            {
                if (highScore > players[i].MyScore) {
                    highScore = players[i].MyScore;
                    winIdx = i;
                }
               
            }
            return winIdx;
        }
    }
}
