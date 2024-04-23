using EmployeeRequestTrackerDALLib;
using EmployeeRequestTrackerModelLib;

namespace EmployeeRequestTrackerTest
{
    public class DepartmentCategory : CategoryAttribute { }
    public class Tests
    {
        IRepository<int, Department> repository;
        [SetUp]
        public void Setup()
        {
            repository = new DepartmentRepository();
        }
        [Test]
        [DepartmentCategory]
        public void AddDepartmentSuccessTest()
        {

            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.That(result.Id, Is.EqualTo(1), "Department should be added in a empty collection, with id of 1");
        }

        [Test]
        [DepartmentCategory]
        public void AddDepartmentFailTest()
        {
            //Arrange 
            Department department = new Department() { Name = "IT", Department_Head = 101 };
            repository.Add(department);
            department = new Department() { Name = "IT", Department_Head = 102 };
            //Action
            var result = repository.Add(department);
            //Assert
            Assert.That(result, Is.Null, "No department with same name should be added");
        }

        [Test]
        public void GetAllDepartmentPassTest()
        {
            Department D1 = new() { Name = "D1", Department_Head = 101 };
            Department D2 = new() { Name = "D2", Department_Head = 101 };

            repository.Add(D1);
            repository.Add(D2);

            var result = repository.GetAll();

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(result[0], Is.EqualTo(D1));
                Assert.That(result[1], Is.EqualTo(D2));
            });
        }

        //[Test]
        //public void GetAllDepartmentFailTest() { 

        //}

        [TestCase(1, "Hr", 101)]
        [TestCase(2, "Admin", 101)]
        public void GetPassTest(int id, string name, int hid)
        {
            //Arrange 
            Department department = new Department() { Name = name, Department_Head = hid };
            repository.Add(department);

            //Action
            var result = repository.Get(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}