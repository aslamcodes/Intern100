using DoctorClinicDALLibrary.Context;
using DoctorClinicDALLibrary.Models;


namespace DoctorClinicDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly DoctorclinicContext _context;
        public PatientRepository()
        {
            _context = new DoctorclinicContext();
        }

        public Patient Add(Patient item)
        {
            try
            {
                var patient = _context.Patients.Add(item);
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Patient Delete(int id)
        {
            try
            {
                var patient = _context.Patients.SingleOrDefault(patient => patient.Id == id)
                    ?? throw new Exception("Patient not found");

                _context.Patients.Remove(patient);

                _context.SaveChanges();

                return patient;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Patient> GetAll()
        {
            try
            {
                var patients = _context.Patients.ToList();
                return patients;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Patient GetByID(int id)
        {
            try
            {
                var patient = _context.Patients.SingleOrDefault(patient => patient.Id == id)
                    ?? throw new Exception("Patient not found");

                return patient;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Patient Update(Patient item)
        {
            try
            {
                _context.Patients.Update(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
