using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicBLLibrary
{
    public interface IDoctorService
    {
        Doctor CreateDoctor(Doctor doctor);

        Doctor ChangeDoctorName(string DoctorOldName, string DoctorNewName);

        Doctor GetDoctorById(int id);

        List<Appointment> GetDoctorAppointments(Doctor doctor);

        Doctor DeleteDoctorByID(int id);
    }
}
