using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * AUTOR: César Gilberto Solares Castellanos
 * Fecha: 22/04/2024 12:07 AM
 * Descripcion: Record para la actualizacion de un curso.

 */
namespace SistemaAsistencia.Contracts.SistemaAsistencia.Courses
{
    public record UpsertCourseRequest(
    string Name,
    DateTime CreatedAt,
    DateTime LastTimeModified
        );
}
