using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAsistencia.Contracts.SistemaAsistencia.Carrera
{
    public record UpsertCareerRequest(
        string Nombre,
        string Nivel,
        DateTime CreatedAt
        );
}
