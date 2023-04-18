using System;
using System.Collections.Generic;

namespace prueba_1_hp.Models;

public partial class EstudianteAsignatura
{
    public int EstudianteIdEstudiante { get; set; }

    public int AsignaturaIdAsignatura { get; set; }

    public int Id { get; set; }

    public virtual Asignatura AsignaturaIdAsignaturaNavigation { get; set; } = null!;

    public virtual Estudiante EstudianteIdEstudianteNavigation { get; set; } = null!;
}
