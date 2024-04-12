namespace CardVerifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
           CardVerifierHub cardVerifierHub = new(16);

            if (cardVerifierHub.VerifyCard("abc"))
            {
                Console.WriteLine("Card Valid");
            }
            else {
                Console.WriteLine("Card not Valid");
            }
            
        }
    }
}
