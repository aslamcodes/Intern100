using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Arithmetic
{

    //    Create a application
    //    that will take username and password from user.

    //    check if username is "ABC" and passwod is "123". 
    //
    //    Print error message if username or password is wrong
    //    Allow user 3 attemts.
    //    After 3rd attempt if user enters invalid credentials then print msg to intimate user
    //    taht he/she has exceeded the number of attempts and stop

    internal class UserNamePasswordChecker
    {
        public string? username;
        public string? password;

        public UserNamePasswordChecker()
        {
            
            this.CheckPassword();
        }

        private void CheckPassword( int times = 3) {
            int attempts = 0;

            while (true)
            {
                Console.WriteLine("Enter your username");
                this.username = Console.ReadLine();

                Console.WriteLine("Enter your password");
                this.password = Console.ReadLine();

                if(this.username != "abc") {
                    Console.WriteLine($"No username found as {this.username}");
                    return;
                }

                while(attempts < times - 1) {
                    if(this.password == "123") {
                        Console.WriteLine("You're logged in!");
                        return;
                    }
                    Console.WriteLine("Wrong Password, please enter again");
                    this.password = Console.ReadLine();
                    attempts++;
                }

                return;

            }
        }
    }
}
