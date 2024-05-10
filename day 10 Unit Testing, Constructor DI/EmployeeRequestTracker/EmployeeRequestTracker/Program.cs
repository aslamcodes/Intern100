using EmployeeRequestTrackerModelLib;
using System.Collections;

namespace EmployeeRequestTracker
{
    internal class Program
    {
        //void UnderstaingList()
        //{
        //    ArrayList list = new ArrayList();
        //    list.Add(100);
        //    list.Add("Hello");
        //    list.Add(23.4);
        //    list.Add(90.3f);
        //    double total = 0;
        //    list.Add(new Employee(101, "Ramu", new DateTime(), "Admin"));
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        Console.WriteLine(list[i]);
        //        total = Convert.ToDouble(list[i]);
        //    }
        //}
        //void UnderstandingGenericList()
        //{
        //    List<int> numbers = new List<int>();
        //    numbers.Add(100);
        //    numbers.Add(79);
        //    numbers.Add(55);
        //    numbers.Add(79);
        //    double total = 0;
        //    //for (int i = 0;i < numbers.Count;i++)
        //    //{
        //    //    Console.WriteLine(numbers[i]);
        //    //    total += numbers[i];
        //    //}
        //    foreach (int i in numbers)
        //    {
        //        Console.WriteLine(i);
        //        total += i;
        //    }
        //    Console.WriteLine($"Total is {total}");
        //}
        //void UnderstandingSet()
        //{
        //    HashSet<string> names = new HashSet<string>()
        //    {
        //        "Ramu","Bimu"
        //    };
        //    names.Add("Somu");
        //    names.Add("Komu");
        //    names.Add("Timu");
        //    names.Add("Ramu");
        //    foreach (string name in names)
        //    {
        //        Console.WriteLine(name);
        //    }
        //}
        //void UnderstandingDictionary()
        //{
        //    Dictionary<int, string> employees = new()
        //    {
        //        { 101, "Ramu" },
        //        { 102, "Komu" },
        //        { 103, "Bimu" },
        //        { 104, "Ramu" }
        //    };

        //    foreach (var key in employees.Keys)
        //    {
        //        Console.WriteLine(key + " " + employees[key]);
        //    }
        //    if (employees.ContainsKey(101))
        //        Console.WriteLine("employee 101 present and name is " + employees[101]);
        //    if (employees.ContainsValue("Somu"))
        //        Console.WriteLine("there is an emploeye with name Somu in teh collection");
        //}
        static void Main(string[] args)
        {

            //new Program().UnderstandingDictionary();
            Dictionary<int, int> d = new Dictionary<int, int>();
            d.Add(1, 2);
            d.Add(10, 2);
            Console.WriteLine(d.Keys.Max());
        }
    }
}
