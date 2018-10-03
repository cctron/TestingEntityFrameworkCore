using System;
using System.ComponentModel.DataAnnotations;

namespace TestingEntityFrameworkCoreCodeFirst.Data
{
    public class Alumnos
    {
        [Key]
        public int IdAlumno { get; set; } //Clave primaria
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int IdCurso { get; set; } //Campo clave foranea

        //Entity Framewrok Core
        public Cursos Curso { get; set; } //Objeto de navegación virtual EFC
    }
}
