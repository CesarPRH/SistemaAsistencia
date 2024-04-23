using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services.CareersInCourses
{

    /*
     * Autor: César Gilberto Solares Castellanos
     * Fecha: 22/04/2024
     * Descripcion: Interface para la tabla ternaria CoursesCareers, usado para asignar cursos en sus carreras respectivas
     */
    public interface ICourseInCareerService
    {
        void CreateAssignmentCourse(CoursesCareers coursesCareers);

        CoursesCareers GetAssignment(Guid id);

        void UpsertAssignmentCourse(CoursesCareers coursesCareers);

        void DeleteAssignmentCourse(Guid guid);
    }

}
