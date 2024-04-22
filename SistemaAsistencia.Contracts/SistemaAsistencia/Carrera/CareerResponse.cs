namespace SistemaAsistencia.Contracts.SistemaAsistencia.Carrera;

/*
*   Autor: César Gilberto Solares Castellanos
*   Fecha: 19/04/2024 20:20PM
*   Descripcion: Clase C# donde se almacena un record, 
*   utilizado para cada response que utiliza nuestro API.
*/

public record CareerResponse(
    Guid Id,
    string Nombre,
    string Nivel,
    DateTime CreatedAt,
    DateTime LastModifiedateTime
);