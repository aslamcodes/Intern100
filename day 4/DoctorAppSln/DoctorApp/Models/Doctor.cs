using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//) Create a Doctor class with details
//Id, Name, Age, Exp, Qualification, Speciality
 
//2) Create an array of doctors
 
//3) Print the array
 
//4) Given a speciality print the doctor details in it

namespace DoctorApp.Models
{ 
    internal class Doctor
    {
        public int Id { get; set; } 
        public string Name { get; set; }    

        public int Experience { get; set; }

        public string Qualification {  get; set; }

        public string Speciality { get; set; }

       public Doctor(int id) {
            Id = id;   
       }

        /// <summary>
        /// Creates a Doctor
        /// </summary>
        /// <param name="name">Name of the Doctor</param>
        /// <param name="experience">Experience of Doctors in years</param>
        /// <param name="qualification">Qualification of The doctor</param>
        /// <param name="speciality">Speciality</param>
        public Doctor(int id, string name, int experience, string qualification, string speciality) : this(id) 
        {
            Name = name;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }
    }
}
