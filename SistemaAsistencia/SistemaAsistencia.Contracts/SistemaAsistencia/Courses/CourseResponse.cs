using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * AUTOR: César Gilberto Solares Castellanos
 * Fecha: 22/04/2024 12:07 AM
 * Descripcion: Record para el procesamiento de solicitud de 
 * cursos, donde lo podemos utilzar para actualizar, borrar
 * o solamente conseguir informacion.

 */
namespace SistemaAsistencia.Contracts.SistemaAsistencia.Courses
{
    public record CourseResponse(
        Guid Id,
        string Name,
        DateTime CreatedAt,
        DateTime LastTimeModified
        );
}
