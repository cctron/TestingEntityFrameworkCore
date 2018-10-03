using System;
using TestingEntityFrameworkCore.Models;

namespace TestingEntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddingData();
        }

        static void AddingData()
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
        }
    }
}
