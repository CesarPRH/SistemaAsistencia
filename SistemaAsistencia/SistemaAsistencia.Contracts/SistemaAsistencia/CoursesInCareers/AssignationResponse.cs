using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAsistencia.Contracts.SistemaAsistencia.CoursesInCareers
{
    public record AssignationResponse
    (
         Guid IdCourseInCareer,
         Guid IdCourse,
         Guid IdCareer,
         DateTime CreatedAt,
         DateTime LastTimeModified
        );
}
