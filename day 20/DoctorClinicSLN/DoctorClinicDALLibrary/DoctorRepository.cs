using DoctorClinicDALLibrary.Context;
using DoctorClinicDALLibrary.Models;

namespace DoctorClinicDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly DoctorclinicContext _context;


        public DoctorRepository()
        {
            _context = new DoctorclinicContext();
        }


        public Doctor Add(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return doctor;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Doctor Delete(int id)
        {
            try
            {
                var doctor = _context.Doctors.Single(doctor => doctor.Id == id);
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return doctor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Doctor> GetAll()
        {
            try
            {
                var doctors = _context.Doctors.ToList();
                return doctors;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public Doctor GetByID(int id)
        {
            try
            {
                var doctor = _context.Doctors.Single(doctor => doctor.Id == id);
                return doctor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Doctor Update(Doctor doctor)
        {
            try
            {
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return doctor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
