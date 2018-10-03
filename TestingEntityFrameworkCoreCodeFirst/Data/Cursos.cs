using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TestingEntityFrameworkCoreCodeFirst.Data
{
    public class Cursos
    {
        //Inicializamos el objeto de navegacion virtual de Entity Framework Core
        public Cursos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        [Key]
        public int IdCurso { get; set; } //Clave primaria
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int IdProfesor { get; set; } //Campo clave foranea

        //Entity Framewrok Core
        public Profesores Profesor { get; set; } //Objeto de navegación virtual EFC
        public ICollection<Alumnos> Alumnos { get; set; } //Objeto de navegación virtual EFC
    }
}
