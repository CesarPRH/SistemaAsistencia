using Microsoft.EntityFrameworkCore;

namespace SistemaAsistencia.Models
{
    public class SystemDatabaseContext : DbContext
    {
        public DbSet<Career> Careers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CoursesCareers> CoursesInCareers { get; set; }

        //Esto solo era para prueba. Borrar porfis
       // public DbSet<Perro> PerrosTabla { get; set; }

        public DbSet<Permit> Permits { get; set; }

        public SystemDatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
