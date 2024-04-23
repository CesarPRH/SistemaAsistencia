using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services.Carreras;

/*
    AUTOR: César Gilberto Solares Castellanos
    Fecha: 20/04/2024
    Descripcion: Servicio del API para carreras. utiliza el interface ICarreraService.

*/

public class CareerService : ICareerService
{
    //Instanciamos _dbContext para las acciones.
    private readonly SystemDatabaseContext _dbContext;
    public CareerService(SystemDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

//Metodo que permite crear una carrera. 
    public void CreateCareer(Career career)
    {
        _dbContext.Careers.Add(career);
        _dbContext.SaveChanges();
    }

 //Metodo que permite conseguir información de una carrera.
 //TODO: Conseguir lista completa de carreras.
    public Career GetCareer(Guid id)
    {
        //Puede ser que salga NULL aqui. El error se arregla en
        //El controlador utilizando un 404 Not Found.
        return _dbContext.Careers.FirstOrDefault(c => c.Id == id);

    }

//Metodo que permite actualizar una carrera
    public void UpsertCareer(Career career)
    {
        var existingCareer = _dbContext.Careers.FirstOrDefault(c => c.Id == career.Id);
    
        if(existingCareer != null)
        {
            existingCareer.Nombre = career.Nombre;
            existingCareer.Nivel = career.Nivel;
            existingCareer.LastTimeModified = DateTime.UtcNow;
        }
        else
        {
            _dbContext.Careers.Add(career);
        }

        _dbContext.SaveChanges ();
    }

//Metodo que permite borrar una carrera.
    public void DeleteCareer(Guid id)
    {
        var careerToDelete = _dbContext.Careers.FirstOrDefault(c => c.Id == id);

        if(careerToDelete != null)
        {
            _dbContext.Careers.Remove(careerToDelete);
            _dbContext.SaveChanges();
        }
    }
}