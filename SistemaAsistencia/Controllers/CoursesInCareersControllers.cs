using Microsoft.AspNetCore.Mvc;
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

        //No se ha terminado.

    }
}
