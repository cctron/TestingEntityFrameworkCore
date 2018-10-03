using System;
using System.Collections.Generic;

namespace TestingEntityFrameworkCore.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public int? IdProfesor { get; set; }

        public Profesores IdProfesorNavigation { get; set; }
        public ICollection<Alumnos> Alumnos { get; set; }
    }
}
