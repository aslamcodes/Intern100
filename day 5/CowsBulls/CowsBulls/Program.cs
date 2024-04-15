using CowsBullsModelLib;

namespace CowsBulls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CowsBullsGameService cowBullGame = new();

            Player p1 = new("Andy");
            Player p2 = new("Gandy");

            Player[] players = [p1, p2];

            int winner = cowBullGame.StartGame(players, "golf");

            Console.WriteLine($"{players[winner].Name} wins");
        }
    }
}
