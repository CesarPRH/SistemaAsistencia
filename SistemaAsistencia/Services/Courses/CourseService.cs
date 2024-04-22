using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services.Courses
{

    /*
     * AUTOR: César Gilberto Solares Castellanos
     * Fecha: 22/04/2024
     * Descripcion: Servicio del API para los cursos.
     * 
     */
    public class CourseService : IcourseService
    {
        //Instancia de SystemDataBaseContext para el uso de la base de datos.
        private readonly SystemDatabaseContext _dbContext;
        public CourseService(SystemDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Metodo para crear un curso.
        public void CreateCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        //Metodo que permite conseguir informacion de un curso.
        public Course GetCourse(Guid id)
        {
            return _dbContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        //metodo que permite actualizar informacion de un curso, o actualizar
        //en el caso que no exista.
        public void UpsertCourse(Course course)
        {
            var existingCourse = _dbContext.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = course.Name;
                existingCourse.LasttimeModified = DateTime.UtcNow;
            }
            else
            {
                _dbContext.Courses.Add(course);
            }
            _dbContext.SaveChanges();

        }

        //Metodo que permite borrar un curso.
        public void DeleteCourse(Guid id)
        {
            var courseToDelete = _dbContext.Courses.FirstOrDefault(c => c.Id == id);
            if(courseToDelete != null)
            {
                _dbContext.Courses.Remove(courseToDelete);
                _dbContext.SaveChanges();
            }
        }

    }
}
