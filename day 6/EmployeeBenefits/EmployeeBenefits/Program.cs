using EmployeeBenefitsModelLibrary;
using System.Xml.Linq;

namespace EmployeeBenefits
{
    public class Program
    {
        public Employee? employee = null;

      
        public void UI()
        {
            int choice;
            do {
                Console.WriteLine("Enter a Choice");

                Console.WriteLine("1. Create Employee");

                Console.WriteLine("2. Show Employee");

                Console.WriteLine("3. Get Salary Details");

                Console.WriteLine("0. Quit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 0: Console.WriteLine("Bye"); break;
                    case 1:
                        if (employee != null) {
                            Console.WriteLine("Employee already created!");
                            break;
                        }
                        employee = Employee.BuildEmployeeFromConsole();
                        break;
                    case 2:
                        if (employee == null)
                        {
                            Console.WriteLine("Create Employee first!");
                            break;
                        }
                        Console.WriteLine(employee);
                        break;
                    case 3:
                        if (employee == null)
                        {
                            Console.WriteLine("Create Employee first!");
                            break;
                        }
                        Console.WriteLine(employee.GetSalaryDetailsFromCompany());
                        break;
                    default: Console.WriteLine("Invalid Choice"); break;
                }
            
            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            new Program().UI();
        }
    }
}
