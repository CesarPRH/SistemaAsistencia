using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services.Courses
{
    /*
     * AUTOR: César Gilberto Solares Castellanos
     * Fecha:22/04/2024 8:11AM
     * Descripcion: Interface para el servicio de Cursos.
     * 
     */

    public interface IcourseService
    {
        void CreateCourse(Course course);
        Course GetCourse(Guid id);
        void UpsertCourse(Course course); 
        void DeleteCourse(Guid id);


    }
}
