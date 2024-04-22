using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services;

/*
    AUTOR: César Gilberto Solares Castellanos
    Fecha: 20/04/2024
    Descripcion: Interface para el servicio de Carrera.

*/

public interface ICareerService
{
    void CreateCareer(Career career);
    Career GetCareer(Guid id);
    void UpsertCareer(Career career);
    void DeleteCareer(Guid id);
    
    

}