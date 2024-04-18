using ClassAndProps.Models;

namespace ClassAndProps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[5];

            for (int i = 0; i < employees.Length; i++) {
                Console.WriteLine("Enter the name");
                
                employees[i] = new Employee(1, Console.ReadLine());
            }

            for (int i = 0; i < employees.Length; i++) {
                Console.WriteLine(employees[i].Name);
                Console.WriteLine(employees[i].Work(i * 10 + 10));
            }
            
        }
    }
}
