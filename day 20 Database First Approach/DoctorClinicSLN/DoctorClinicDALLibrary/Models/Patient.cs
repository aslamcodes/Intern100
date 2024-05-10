using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Bloodgroup { get; set; }

    public int? Age { get; set; }

    public string? Sex { get; set; }

    public int? Weight { get; set; }

    public int? Height { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
