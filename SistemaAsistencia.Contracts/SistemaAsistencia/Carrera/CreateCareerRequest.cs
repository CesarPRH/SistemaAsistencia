namespace SistemaAsistencia.Contracts.SistemaAsistencia.Carrera;

/*
    Autor: César Gilberto Solares Castellanos
    Fecha: 19/04/2024 2024PM
    Descripcion: Clase C# donde se almacena un record, 
   utilizado para cada el request para crear una nueva carrera.    

*/

public record CreateCareerRequest(
    string Nombre,
    string Nivel,
    DateTime CreatedAt

);