using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * blah blah blah. Record para la solicitar de informacion de permiso.
 */
namespace SistemaAsistencia.Contracts.SistemaAsistencia.Permit
{
    public record PermitResponse
    (
        Guid IdPermit,
        Guid IdStudent,
        Guid IdProfessorInCourse,
        string Motive,
        DateTime AbsenceDate,
        // El tipo byte accepta archivos
        byte[] Proof,
        DateTime CreatedAt,
        DateTime LastTimeModified
        );
}
