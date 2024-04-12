using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Models
{
    internal class Hospital
    {

        Doctor[] doctors = [];

        public Hospital() {
            
        }

        internal void SignUpDoctors(int v)
        {
            doctors = new Doctor[v];

            for (int i = 0; i < doctors.Length; i++)
            {
                doctors[i] = new Doctor(100 + i);

                Console.WriteLine("Please enter the doctor's name: ");
                doctors[i].Name = Console.ReadLine();

                Console.WriteLine("Please enter the Qualification: ");
                doctors[i].Qualification = Console.ReadLine();

                Console.WriteLine("Enter Speciality");
                doctors[i].Speciality = Console.ReadLine();

                Console.WriteLine("Please enter the Year of Experience");
                
                int yearofEx;
                while (!int.TryParse(Console.ReadLine(), out yearofEx))
                {
                    Console.WriteLine("Invalid entry. Please try again.");
                }
                doctors[i].Experience = yearofEx;

               

            }
        }

        internal void ShowDoctor(int idx) {
            Console.WriteLine("\n\n***************");
            Console.WriteLine($"\nName: {doctors[idx].Name}");
            Console.WriteLine($"Qualification: ${doctors[idx].Qualification}");
            Console.WriteLine($"Specification: ${doctors[idx].Speciality}");
            Console.WriteLine($"Years of Experience: ${doctors[idx].Experience}");
            Console.WriteLine("\n\n***************");
        }
        internal void ShowAllDoctors() { 
        for(int i = 0; i < doctors.Length; i++)
            {
                ShowDoctor(i);
            }
        }
        internal void GetDoctorsBySpeciality(string speciality) {
            for (int i = 0; i < doctors.Length; i++) {
                if (doctors[i].Speciality == speciality)
                {
                    ShowDoctor(i);
                }
            }
        }
    }
}
