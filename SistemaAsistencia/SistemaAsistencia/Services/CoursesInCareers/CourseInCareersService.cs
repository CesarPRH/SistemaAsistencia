using SistemaAsistencia.Models;
using SistemaAsistencia.Services.CareersInCourses;

/*
 * Autor: César Gilberto Solares Castellanos
 * Fecha:22/04/2024 15:00PM
 * Descripcion: Servicio del API para la asignacion de los cursos en sus
 * carreras respectivas. Lamentablemente las variables terminaron siendo
 * un poquito complicados :(
 */
namespace SistemaAsistencia.Services.CoursesInCareers
{
    public class CourseInCareersService : ICourseInCareerService
    {

        //Instancia de dbContext para las interacciones de nuestra base de datos.
        private readonly SystemDatabaseContext _dbContext;

        public CourseInCareersService(SystemDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Mmetodo para asignar un curso con su carrera.
        public void CreateAssignmentCourse(Models.CoursesCareers coursesCareers)
        {
            _dbContext.Add(coursesCareers);
            _dbContext.SaveChanges();
        }


        //Metodo para conseguiir informacion de la asignacion.
        public CoursesCareers GetAssignment(Guid id)
        {
            return _dbContext.CoursesInCareers.FirstOrDefault(c => c.IdCourseInCareer == id);
        }

        //Metodo para actualizar la asignacion por si existe, y si no entonces
        //lo crea.
        public void UpsertAssignmentCourse(CoursesCareers coursesCareers)
        {
            var existingAssignment = _dbContext.CoursesInCareers.FirstOrDefault(c => c.IdCourseInCareer == coursesCareers.IdCourseInCareer);
            if (existingAssignment != null)
            {
                existingAssignment.CourseId = coursesCareers.CourseId;
                existingAssignment.CareerId = coursesCareers.CareerId;
                existingAssignment.LastTimeModified = DateTime.UtcNow;
            }
            else
            {
                _dbContext.CoursesInCareers.Add(coursesCareers);
            }
            _dbContext.SaveChanges();
        }

        //Metodo para borrar una asignacion.
        public void DeleteAssignmentCourse(Guid id)
        {
            var assignmentToDelete = _dbContext.CoursesInCareers.FirstOrDefault(c => c.IdCourseInCareer == id);

            if(assignmentToDelete != null)
            {
                _dbContext.CoursesInCareers.Remove(assignmentToDelete);
                _dbContext.SaveChanges() ;
            }
        }

    }
}
