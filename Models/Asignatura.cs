using System;
using System.Collections.Generic;

namespace prueba_1_hp.Models;

public partial class Asignatura
{
    public int IdAsignatura { get; set; }

    public string? NombreAsignatura { get; set; }

    public string? DescripcionAsignatura { get; set; }

    public string? CodigoAsignatura { get; set; }

    public DateOnly? FechaActualizacion { get; set; }

    public virtual ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; } = new List<EstudianteAsignatura>();
}
