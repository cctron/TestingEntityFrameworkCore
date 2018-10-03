using Microsoft.EntityFrameworkCore;

namespace TestingEntityFrameworkCoreCodeFirst.Data
{
    class PostDbContext : DbContext
    {
        //Constructor sin parametros
        public PostDbContext()
        {
        }

        //Constructor con parametros para la configuracion
        public PostDbContext(DbContextOptions options)
        : base(options)
        {
        }

        //Sobreescribimos el metodo OnConfiguring para hacer los ajustes que queramos en caso de
        //llamar al constructor sin parametros
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //En caso de que el contexto no este configurado, lo configuramos mediante la cadena de conexion
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=postefcorecodfirst;Uid=root;Pwd=root;");
            }
        }

        //Tablas de datos
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
    }
}
