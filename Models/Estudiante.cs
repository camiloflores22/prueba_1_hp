using System;
using System.Collections.Generic;

namespace prueba_1_hp.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string? NombreEstudiante { get; set; }

    public string? ApellidoEstudiante { get; set; }

    public string? RutEstudiante { get; set; }

    public string? DireccionEstudiante { get; set; }

    public int? Edad { get; set; }

    public string? Email { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<EstudianteAsignatura> EstudianteAsignaturas { get; set; } = new List<EstudianteAsignatura>();
}
