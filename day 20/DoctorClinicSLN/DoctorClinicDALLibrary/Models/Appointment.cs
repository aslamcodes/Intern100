using System;
using System.Collections.Generic;

namespace DoctorClinicDALLibrary.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int? Doctorid { get; set; }

    public int? Patientid { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
