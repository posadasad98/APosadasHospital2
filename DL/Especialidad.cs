﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Especialidad
{
    public int IdEspecialidad { get; set; }

    public string? NombreEspecialidad { get; set; }

    public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
}
