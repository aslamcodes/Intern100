using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Qualification { get; set; }

    public string? Speciality { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
