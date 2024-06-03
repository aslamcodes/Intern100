using Microsoft.EntityFrameworkCore;
using RequestTracker.Contexts;
using RequestTracker.Models;
using RequestTracker.Repositories;
using RequestTracker.Services;

namespace RequestTrackerTesting
{
    public class EmployeeTest
    {

        private RequestTrackerContext Context { get; set; }


        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("EmployeeTest");
            Context = new RequestTrackerContext(optionsBuilder.Options);
            Context.Database.EnsureCreated();

        }

        [Test]
        public async Task Test1()
        {
            IRepository<int, Employee> repository = new EmployeeRepository(Context);
            Employee employee = new Employee { Id = 101, Name = "John Doe", Phone = "123" };
            _ = repository.Add(employee);
            Employee employee1 = await repository.Get(101);

            EmployeeBasicService employeeBasicService = new EmployeeBasicService(repository);
            var result = await employeeBasicService.GetEmployeeByPhone("123");
            Assert.That(result, Is.EqualTo(employee1));

        }
    }
}