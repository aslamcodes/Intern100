using System;

namespace Arithmetic
{
    internal class UserNameLength
    {
        public string Name;

        public UserNameLength()
        {
            Console.WriteLine("Enter your username");

            this.Name = Console.ReadLine();

            Console.WriteLine($"Length of the username is {this.Name.Length}");
        }
    }

}