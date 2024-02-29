using System;
using System.Collections.Generic;

namespace DL;

public partial class Hospital
{
    public int IdHospital { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public DateTime? AniodeConstruccion { get; set; }

    public int? IdEspecialidad { get; set; }

    public virtual Especialidad? IdEspecialidadNavigation { get; set; }
}
