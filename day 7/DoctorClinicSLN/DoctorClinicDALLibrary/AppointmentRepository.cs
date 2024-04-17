using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorClinicModelLib;
namespace DoctorClinicDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> _appointments;


        public AppointmentRepository()
        {
            _appointments = [];
        }

        int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            // Research more about this
            int id = _appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment appointment)
        {
            if (_appointments.ContainsValue(appointment))
            {
                return null;
            }
            _appointments.Add(GenerateId(), appointment);
            return appointment;
        }

        public Appointment Delete(int id)
        {
            if (_appointments.ContainsKey(id))
            {
                var appointment = _appointments[id];
                _appointments.Remove(id);
                return appointment;
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        public Appointment GetByID(int id)
        {
            return _appointments.ContainsKey(id) ? _appointments[id] : null;
        }

        public Appointment Update(Appointment appointement)
        {
            if (_appointments.ContainsKey(appointement.Id))
            {
                _appointments[appointement.Id] = appointement;
                return appointement;
            }
            return null;
        }
    }
}
