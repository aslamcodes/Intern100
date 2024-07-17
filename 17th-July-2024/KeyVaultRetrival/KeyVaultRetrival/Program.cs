using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace KeyVaultRetrival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string secretName = "random-key";
            string keyVaultName = "aslamsecrets ";
            var kvUri = "https://aslamsecrets.vault.azure.net/";

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
            };

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret(secretName);

            Console.WriteLine("Your secret is '" + secret.Value + "'.");

            Console.Read();
        }
    }
}
