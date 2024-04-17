using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DoctorClinicModelLib;

namespace DoctorClinicDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = [];
        }

        int GenerateId()
        {
            if (_doctors.Count == 0)
                return 1;
            // Research more about this
            int id = _doctors.Keys.Max();
            return ++id;
        }

        public Doctor Add(Doctor doctor)
        {

            if (_doctors.ContainsValue(doctor))
            {
                return null;
            }
            _doctors.Add(GenerateId(), doctor);
            return doctor;
        }

        public Doctor Delete(int id)
        {
            if (_doctors.ContainsKey(id))
            {
                var doctor = _doctors[key];
                _doctors.Remove(id);
                return doctor;
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Count == 0)
                return null;
            return _doctors.Values.ToList();

        }

        public Doctor GetByID(int id)
        {
            return _doctors.ContainsKey(id) ? _doctors[id] : null;
        }

        public Doctor Update(Doctor doctor)
        {
            if (_doctors.ContainsKey(doctor.Id))
            {
                _doctors[doctor.Id] = doctor;
                return doctor;
            }
            return null;
        }
    }
}
