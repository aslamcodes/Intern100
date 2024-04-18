using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndProps.Models
{
    internal class Employee
    {
        /// <summary>
        /// Id of the Employee
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Employee
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Employee()
        {
            Name = string.Empty;
        }

        /// <summary>
        /// Creates a Employee with id and name
        /// </summary>
        /// <param name="id">Id of the Employee</param>
        /// <param name="name">Name of the Employee</param>
        public Employee(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
       /// <summary>
       /// Works for give hours
       /// </summary>
       /// <param name="hours">Number of Hours</param>
       /// <returns>Working hours of the employee</returns>
        public string Work(int hours) {
            return $"Worked for {hours}";
        }
    }
}

