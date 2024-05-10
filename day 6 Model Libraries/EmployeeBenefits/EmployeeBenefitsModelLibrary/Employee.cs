namespace EmployeeBenefitsModelLibrary
{
    public class Employee
    {
        public  int EmpId { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public double BasicSalary { get; set; }

        public ICompanyWithGovtRules Company { get; set; }

        public Employee(int id) {
            EmpId = id + 100;
        }

        public Employee(int empId, string name, string department, string designation, double basicSalary, ICompanyWithGovtRules company)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
            Company = company;
        }

        public static Employee BuildEmployeeFromConsole()
        {
            Console.WriteLine("Enter Employee Name");
            string name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Enter Depeartment");
            string department = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Enter Designation");
            string designation = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Enter Basic Salary");
            double salary = Convert.ToDouble(Console.ReadLine() ?? String.Empty);
            Console.WriteLine("Select Company: \n1. CTS\n2. Accenture");
            int choice = Convert.ToInt32(Console.ReadLine());
            ICompanyWithGovtRules company;
            if(choice == 1)
            {
                company = new CTS();
            } 
            else
            {
                company = new Accenture();
            }

            return new Employee(100, name, department, designation, salary, company);
        }

        public string GetSalaryDetailsFromCompany()
        {
            return Company.GetSalaryDetails(BasicSalary);
        }

        public override string ToString()
        {
            return $"ID: {EmpId}\nName: {Name}\nDepartment: {Department}\nDesignation: {Designation}\nCompany :{Company.Name}\n{Company.GetSalaryDetails(BasicSalary)}";
        }
    }
}
