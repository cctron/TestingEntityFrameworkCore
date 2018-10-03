using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestingEntityFrameworkCoreCodeFirst.Data;

namespace TestingEntityFrameworkCoreCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void CreatingData()
        {
            using (PostDbContext context = new PostDbContext())
            {
                //Creamos el profesor
                Profesores profesor = new Profesores() { Nombre = "Pedro" };
                context.Add(profesor);
                //Creamos los cursos
                Cursos curso1 = new Cursos() { Nombre = "Matematicas", IdProfesor = profesor.IdProfesor };
                context.Add(curso1);
                Cursos curso2 = new Cursos() { Nombre = "Lenguaje", IdProfesor = profesor.IdProfesor };
                context.Add(curso2);
                //Creamos los alumnos
                Alumnos alumno1 = new Alumnos() { Nombre = "Jorge", IdCurso = curso1.IdCurso };
                context.Add(alumno1);
                Alumnos alumno2 = new Alumnos() { Nombre = "Juan", IdCurso = curso1.IdCurso };
                context.Add(alumno2);
                Alumnos alumno3 = new Alumnos() { Nombre = "Andrea", IdCurso = curso2.IdCurso };
                context.Add(alumno3);
                Alumnos alumno4 = new Alumnos() { Nombre = "Sandra", IdCurso = curso2.IdCurso };
                context.Add(alumno4);
                //Guardamos los cambios
                context.SaveChanges();
            }

            using (PostDbContext context = new PostDbContext())
            {
                var profesor = context.Profesores //Indicamos la tabla
                                      .Include(x => x.Cursos) //Incluimos los resultados coincidentes de la tabla cursos (inner join)
                                      .ThenInclude(x => x.Alumnos) //Incluimos los resultados coincidentes de la tabla alumnos (inner join)
                                      .First(); //Seleccionamos el primero
                foreach (var curso in profesor.Cursos)
                    foreach (var alumno in curso.Alumnos)
                        Console.WriteLine($"El alumno {alumno.Nombre} recibe el curso de {curso.Nombre},impartido por {profesor.Nombre}");
            }
        }
    }
}
