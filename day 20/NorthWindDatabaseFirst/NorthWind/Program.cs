using NorthWind.Models;

namespace NorthWind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer c = new Customer();
            //c.CustomerId = "1";
            //c.ContactName = "John Doe";
            //c.CompanyName = "Acme";
            //c.ContactTitle = "CEO";
            //c.Address = "123 Main St";
            //c.City = "Springfield";
            //c.Region = "IL";
            //c.PostalCode = "62701";
            //c.Country = "USA";
            //c.Phone = "555-555-5555";
            //c.Fax = "555-555-5556";
            //c.Orders = new List<Order>();
            //c.CustomerTypes = new List<CustomerDemographic>();

            var ctx = new NorthWindContext();
            //ctx.Customers.Add(c);
            var c = ctx.Customers.SingleOrDefault(customer => customer.CustomerId == "1");
            c.ContactName = "Jane Dea";
            ctx.Customers.Remove(c);
            ctx.SaveChanges();

            //ctx.Suppliers.ToList().ForEach(s => System.Console.WriteLine(s.CompanyName));


        }
    }
}
