using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Contracts.SistemaAsistencia.Courses;
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
            if( coursesCareers == null )
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

        [HttpPut("{id:guid}")]
        //Perdon por la variable larga, es la mas entendible que pude pensar :(
        public IActionResult UpsertAssignmentCourse(Guid id, UpsertCoursesInCareerAssignation request)

        {
            CoursesCareers existingAssignment = _coursesInCareersService.GetAssignment(id);

            if(existingAssignment != null)
            {
                existingAssignment.CourseId = request.IdCourse;
                existingAssignment.CareerId = request.IdCareer;

                _coursesInCareersService.UpsertAssignmentCourse(existingAssignment);

                var response = new AssignationResponse(
                    existingAssignment.IdCourseInCareer,
                    existingAssignment.CourseId,
                    existingAssignment.CareerId,
                    existingAssignment.CreatedAt,
                    existingAssignment.LastTimeModified
                    );
                return Ok(response);
            }
            else
            {
                var newAssignation = new CoursesCareers(
                    Guid.NewGuid(),
                    request.IdCourse,
                    request.IdCareer,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );
                _coursesInCareersService.CreateAssignmentCourse(newAssignation);

                var response = new CoursesCareers(
                    newAssignation.IdCourseInCareer,
                    newAssignation.CourseId,
                    newAssignation.CareerId,
                    newAssignation.CreatedAt,
                    newAssignation.LastTimeModified
                    );


                return CreatedAtAction(
                    actionName: nameof(GetAssignment),
                    routeValues: new {id = newAssignation.IdCourseInCareer},
                    value : response
                    );
            }

        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteAssignment(Guid id)
        {
            CoursesCareers Assignation = _coursesInCareersService.GetAssignment(id);
            if(Assignation == null )
            {
                return NotFound();
            }
            _coursesInCareersService.DeleteAssignmentCourse(id);
            return NoContent();
        }
    }
}
