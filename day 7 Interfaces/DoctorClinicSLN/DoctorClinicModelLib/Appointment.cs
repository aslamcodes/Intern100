using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicModelLib
{
    public class Appointment(Doctor doctor, Patient patient, DateTime date)
    {
        public int Id { get; set; }
        public Doctor AppointedDoctor { get; set; } = doctor;

        public Patient Patient { get; set; } = patient;

        public DateTime Date { get; set; } = date;

        public override bool Equals(object? obj)
        {
            return Id == (obj as Appointment).Id;
        }
    }
}
