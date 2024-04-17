using DoctorClinicModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClinicDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _departments;

        public PatientRepository()
        {
            _departments = [];
        }
        int GenerateId()
        {
            if (_departments.Count == 0)
                return 1;
            // Research more about this
            int id = _departments.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_departments.ContainsValue(item))
            {
                return null;
            }
            _departments.Add(GenerateId(), item);
            return item;
        }

        public Patient Delete(int id)
        {
            if (_departments.ContainsKey(id))
            {
                var department = _departments[id];
                _departments.Remove(id);
                return department;
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if (_departments.Count == 0)
                return null;
            return [.. _departments.Values];
        }

        public Patient GetByID(int id)
        {
            return _departments.ContainsKey(id) ? _departments[id] : null;
        }

        public Patient Update(Patient item)
        {
            if (_departments.ContainsKey(item.Id))
            {
                _departments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
