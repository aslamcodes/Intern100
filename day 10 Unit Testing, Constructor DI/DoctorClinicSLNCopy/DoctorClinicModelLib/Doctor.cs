using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicModelLib
{
    public class Doctor(string name, string qualification, string speciality)
    {
        public int Id { get; set; }
        public string Name { get; set; } = name;

        public string Qualification { get; set; } = qualification;

        public string Speciality { get; set; } = speciality;

        public override bool Equals(object? obj)
        {
            return Id == (obj as Doctor).Id;
        }
    }
}
