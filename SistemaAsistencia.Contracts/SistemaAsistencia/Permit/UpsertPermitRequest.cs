using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Record para la actualizacion de permisos.
 */
namespace SistemaAsistencia.Contracts.SistemaAsistencia.Permit
{
    public record UpsertPermitRequest
    (
        //Guid IdPermit,
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
