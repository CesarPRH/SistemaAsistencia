using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Contracts.SistemaAsistencia.CoursesInCareers;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services.CareersInCourses;
using SistemaAsistencia.Services.CoursesInCareers;

namespace SistemaAsistencia.Controllers
{
    [ApiController]
    [Route("courseInCareer")]
    /*
     * NOTA: Este controlador no se utilizara al final, ya que
     * Se piensa implementar CoursesCareer en CoursesControllers
     * Por razon de asignacion imediata.
     */
    public class CoursesInCareersControllers : ControllerBase
    {
        private readonly CourseInCareersService _coursesInCareersService;

        public CoursesInCareersControllers(ICourseInCareerService coursesInCareersService)
        {
            _coursesInCareersService = (CourseInCareersService?)coursesInCareersService;
        }


        [HttpPost]
        public IActionResult CreateAssignmentCourse(AsignCoursesInCareersRequest request)
        {
            var coursesCareer = new CoursesCareers(
                Guid.NewGuid(),
                request.IdCourse,
                request.IdCareer,
                DateTime.UtcNow,
                DateTime.UtcNow);
            _coursesInCareersService.CreateAssignmentCourse(coursesCareer);

            var response = new AssignationResponse
                (
                coursesCareer.IdCourseInCareer,
                coursesCareer.CourseId,
                coursesCareer.CareerId,
                coursesCareer.CreatedAt,
                coursesCareer.LastTimeModified
                );
            return CreatedAtAction(
                actionName: nameof(GetAssignment),
                routeValues: new {id = coursesCareer.IdCourseInCareer},
                value: response );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAssignment(Guid id)
        {
            CoursesCareers coursesCareers = _coursesInCareersService.GetAssignment(id);
            if( coursesCareers != null )
            {
                return NotFound();
            }
            var response = new AssignationResponse(
                coursesCareers.IdCourseInCareer,
                coursesCareers.CourseId,
                coursesCareers.CareerId,
                coursesCareers.CreatedAt,
                coursesCareers.LastTimeModified
                );
            return Ok(response );

        }

        //No se ha terminado.

    }
}
