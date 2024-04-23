using SistemaAsistencia.Contracts.SistemaAsistencia.Carrera;
using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Services;
using SistemaAsistencia.Models;

namespace SistemaAsistencia.Controllers;

[ApiController]
[Route("careers")]
public class CareersController : ControllerBase
{
	private readonly ICareerService _careerService;

public CareersController(ICareerService careerService)
	{
		_careerService = careerService;
	}
	

	//Metodo utilizado para crear nueva carrera
	[HttpPost]
	public IActionResult CreateCareer(CreateCareerRequest request)
	{
		//Mapeamos los valores con sus campos respectivos
		var career = new Career(
			Guid.NewGuid(),
			request.Nombre,
			request.Nivel,
			DateTime.UtcNow,
			DateTime.UtcNow
			) ;
		_careerService.CreateCareer( career );


		//Ya esta informacion se iria a la base de datos, gracias al servicio CarerreraService

		var response = new CareerResponse(
			career.Id,
			career.Nombre,
			career.Nivel,
			career.CreatedAt,
			career.LastTimeModified
			);

		return CreatedAtAction(
			actionName: nameof(GetCareer),
			routeValues: new { id = career.Id },
			value: response
			);

	}

	//Metodo para conseguir
	[HttpGet("{id:guid}")]
	public IActionResult GetCareer(Guid id)
	{
		Career career = _careerService.GetCareer( id );
		//En el caso que no haya encontrado la carrera
		//Devolvera un 404 not found.
		if (career == null)
		{
			return NotFound();
		}


		var response = new CareerResponse(
			career.Id,
			career.Nombre,
			career.Nivel,
			career.CreatedAt,
			career.LastTimeModified
			);
		return Ok( response );
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpsertCareer(Guid id, UpsertCareerRequest request)
	{
		Career existingCareer = _careerService.GetCareer(id);
		//Buscamos si la carrera existe con esta condicion.
		if(existingCareer != null)
		{
			//Si existe, reasignamos los valores.
			existingCareer.Nombre = request.Nombre;
			existingCareer.Nivel = request.Nivel;
			existingCareer.LastTimeModified = DateTime.UtcNow;

			_careerService.UpsertCareer(existingCareer );

			var response = new CareerResponse(
				existingCareer.Id,
				existingCareer.Nombre,
				existingCareer.Nivel,
				existingCareer.CreatedAt,
				existingCareer.LastTimeModified
				);
			return Ok( response );
		}
		else
		{
			//Si no existe, creamos la carrera.
			var newCareer = new Career(
				 Guid.NewGuid(),
				 request.Nombre,
				 request.Nivel,
				 DateTime.UtcNow,
				 DateTime.UtcNow
				);

			_careerService.CreateCareer(newCareer);

			var response = new CareerResponse(
				newCareer.Id,
				newCareer.Nombre,
				newCareer.Nivel,
				newCareer.CreatedAt,
				newCareer.LastTimeModified
				);

			return CreatedAtAction(
				actionName: nameof(GetCareer),
				routeValues: new { id = newCareer.Id },
				value : response );
		}


	}



	[HttpDelete("{id:guid}")]
	public IActionResult DeleteCareer(Guid id)
	{
		Career career = _careerService.GetCareer(id);
		if (career == null)
		{
			return NotFound();
		}


		_careerService.DeleteCareer(id);
		return NoContent(); ;
	}


}