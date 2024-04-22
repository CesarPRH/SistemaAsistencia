using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAsistencia.Contracts.SistemaAsistencia.CoursesInCareers
{
    public record AsignCoursesInCareersRequest
    (

         Guid IdCourse,
         Guid IdCareer,
         DateTime CreatedAt,
         DateTime LastTimeModified
        );
}
