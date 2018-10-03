using System;
using System.Collections.Generic;

namespace TestingEntityFrameworkCore.Models
{
    public partial class Alumnos
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public DateTime? Nacimiento { get; set; }
        public int? IdCurso { get; set; }

        public Cursos IdCursoNavigation { get; set; }
    }
}
