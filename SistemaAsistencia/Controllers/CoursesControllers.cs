using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Contracts.SistemaAsistencia.Courses;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services.Courses;

/*
 * AUTOR: César Gilberto Solares Castellanos
 * Fecha: 22/04/2024
 * Descripcion: Controlador para Cursos.
 * */
namespace SistemaAsistencia.Controllers
{

    [ApiController]
    [Route("courses")]

    //TODO: Implementar de una vez CoursesCareer para cuando el frontend este listo
    public class CoursesControllers :ControllerBase
    {
        private readonly IcourseService _courseService;

        public CoursesControllers(IcourseService courseService)
        {
            _courseService = courseService;
        }


        //Controlador para crear un nuevo curso.
        [HttpPost]
        public IActionResult CreateCourse(CreateCourseRequest request)
        {
            var course = new Course(
                Guid.NewGuid(),
                request.Name,
                DateTime.UtcNow,
                DateTime.UtcNow
                );
            _courseService.CreateCourse( course );

            var response = new CourseResponse
                (
                course.Id,
                course.Name,
                course.CreatedAt,
                course.LasttimeModified
                );

            return CreatedAtAction(
                actionName: nameof(GetCourse),
                routeValues: new { id = course.Id},
                value: response );

        }
        //controlador para obtener informacion para un curso.
        [HttpGet("{id:guid}")]
        public IActionResult GetCourse(Guid id)
        {
            Course course = _courseService.GetCourse( id );

            if (course == null )
            {
                return NotFound();
            }

            var response = new CourseResponse(
                course.Id,
                course.Name,
                course.CreatedAt,
                course.LasttimeModified
                );

            return Ok( response );
        }

        //Controlador que permite actualizar un curso, o crearlo en el caso que no exista.
        [HttpPut("{id:guid}")]
        public IActionResult UpsertCourse(Guid id, UpsertCourseRequest request)
        {
            Course existingCourse = _courseService.GetCourse( id );
            //Si el curso existe, actualiza.
            if(existingCourse != null)
            {
                existingCourse.Name = request.Name;
                existingCourse.LasttimeModified = DateTime.UtcNow;

                _courseService.UpsertCourse( existingCourse );

                var response = new CourseResponse(
                    existingCourse.Id,
                    existingCourse.Name,
                    existingCourse.CreatedAt,
                    existingCourse.LasttimeModified
                    );
                return Ok( response );
            }
            //Si el curso no existe, lo crea.
            else
            {
                var newCourse = new Course(
                    Guid.NewGuid(),
                    request.Name,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    ) ;

                _courseService.CreateCourse( newCourse );

                var response = new CourseResponse(
                    newCourse.Id,
                    newCourse.Name,
                    newCourse.CreatedAt,
                    newCourse.LasttimeModified
                    );

                return CreatedAtAction(
                    actionName: nameof(GetCourse),
                    routeValues: new {id = newCourse.Id},
                    value : response
                    );
            }

        }


        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCourse( Guid id )
        {
            Course course = _courseService.GetCourse(id);
            if(course == null) {
                return NotFound();
            }
            _courseService.DeleteCourse(id);
            return NoContent();

        }

    }
}
