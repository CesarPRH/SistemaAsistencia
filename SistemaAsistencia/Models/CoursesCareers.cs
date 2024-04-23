using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


/*
 * Autor: César Gilberto Solares Castellanos
 * Fecha: 22/04/2024 11:30AM
 * Descripcion: El modelo par una entidad ternaria, para la asignacion
 * de cursos en cada carrera. Esta tabla es usada para evitar relaciones
 * muchos a muchos.
 */
namespace SistemaAsistencia.Models
{
    public class CoursesCareers
    {
        //Llave primaria
        [Key]
        public Guid IdCourseInCareer { get; set; }

        //Llave foranea para la tabla cursos
        [ForeignKey("courses")]
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        //llave foranea para la tabla carreras
        [ForeignKey("careers")]
        public Guid CareerId { get; set; }
        public Career Career { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastTimeModified { get; set; }


        public CoursesCareers(
            Guid idCourseInCareer,
            Guid courseId,
            Guid careerId,
            DateTime createdAt,
            DateTime lastTimeModified

            )
        {
            IdCourseInCareer = idCourseInCareer;
            CourseId = courseId;
            CareerId = careerId;
            CreatedAt = createdAt;
            LastTimeModified = lastTimeModified;
        }
    }
}
