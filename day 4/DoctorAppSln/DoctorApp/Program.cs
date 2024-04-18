using DoctorApp.Models;

namespace DoctorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital ABCHospital = new();

            ABCHospital.SignUpDoctors(2);

            ABCHospital.ShowAllDoctors();

            Console.Write("\nEnter Speciality: ");
            string speciality = Console.ReadLine();
            ABCHospital.GetDoctorsBySpeciality(speciality);
         }
    }
}
