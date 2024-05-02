using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * AUTOR: CESAR GILBERTO SOLARES CASTELLANOS
 * Fecha: 01/05/2024 20:09PM
 * Descripcion: Record para el procesamiento de request para crear el permiso.
 */
namespace SistemaAsistencia.Contracts.SistemaAsistencia.Permit
{
    public record CreatePermitRequest
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
