using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Contracts.SistemaAsistencia.CoursesInCareers;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services.CareersInCourses;
using SistemaAsistencia.Services.CoursesInCareers;

namespace SistemaAsistencia.Controllers
{
    [ApiController]
    [Route("CourseInCareer")]
    /*
     * NOTA: Este controlador no se utilizara al final, ya que
     * Se piensa implementar CoursesCareer en CoursesControllers
     * Por razon de asignacion imediata.
     */
    public class CoursesInCareersControllers : ControllerBase
    {
        private readonly CourseInCareersService _coursesInCareersService;

        private CoursesInCareersControllers(ICourseInCareerService coursesInCareersService)
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
            return Ok(response);
        }
        //No se ha terminado.

    }
}
