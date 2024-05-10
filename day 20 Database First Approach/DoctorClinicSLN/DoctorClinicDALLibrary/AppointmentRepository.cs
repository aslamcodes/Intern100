using DoctorClinicDALLibrary.Context;
using DoctorClinicDALLibrary.Models;

namespace DoctorClinicDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly DoctorclinicContext _context;

        public AppointmentRepository()
        {
            _context = new DoctorclinicContext();
        }


        public Appointment Add(Appointment appointment)
        {
            try
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return appointment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Appointment Delete(int id)
        {
            try
            {
                var appointment = _context.Appointments.Single(appointment => appointment.Id == id);
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return appointment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Appointment> GetAll()
        {
            try
            {
                var appointments = _context.Appointments.ToList();
                return appointments;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Appointment GetByID(int id)
        {
            try
            {
                var appointment = _context.Appointments.Single(appointment => appointment.Id == id);
                return appointment;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Appointment Update(Appointment appointement)
        {
            try
            {
                _context.Appointments.Update(appointement);
                _context.SaveChanges();
                return appointement;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
