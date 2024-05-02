using Microsoft.AspNetCore.Mvc;
using SistemaAsistencia.Contracts.SistemaAsistencia.Permit;
using SistemaAsistencia.Models;
using SistemaAsistencia.Services.Permits;

namespace SistemaAsistencia.Controllers
{
    [ApiController]
    [Route("permits")]
    public class PermitsControllers :ControllerBase
    {
        private readonly IPermitService _permitService;

        public PermitsControllers(IPermitService permitService)
        {
            _permitService = permitService;
        }

        [HttpPost]
        public IActionResult CreatePermit(CreatePermitRequest request)
        {
            var permit = new Permit(
                Guid.NewGuid(),
                request.IdStudent,
                request.IdProfessorInCourse,
                request.Motive,
                request.AbsenceDate,
                request.Proof,
                DateTime.UtcNow,
                DateTime.UtcNow
                );
                _permitService.CreatePermit( permit );

            var response = new PermitResponse(
                permit.IdPermit,
                permit.IdStudent,
                permit.IdProfessorInCourse,
                permit.Motive,
                permit.AbsenceDate,
                permit.Proof,
                permit.CreatedAt,
                permit.LastTimeModified
                );
            return CreatedAtAction(
                actionName: nameof(GetPermit),
                routeValues: new {id =permit.IdPermit},
                value: response );


        }

        [HttpGet("{id:guid}")]
        public IActionResult GetPermit (Guid id)
        {
            Permit permit = _permitService.GetPermit( id );
            if ( permit == null )
            {
                return NotFound();
            }
            var response = new PermitResponse(
                    permit.IdPermit,
                    permit.IdStudent,
                    permit.IdProfessorInCourse,
                    permit.Motive,
                    permit.AbsenceDate,
                    permit.Proof,
                    permit.CreatedAt,
                    permit.LastTimeModified
                );
            return Ok(response );
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertPermit(Guid id, UpsertPermitRequest request)
        {
            Permit existingPermit = _permitService.GetPermit(id);

            if (existingPermit != null)
            {
                existingPermit.IdStudent = request.IdStudent;
                existingPermit.IdProfessorInCourse = request.IdProfessorInCourse;
                existingPermit.Motive = request.Motive;
                existingPermit.AbsenceDate = request.AbsenceDate;
                existingPermit.Proof = request.Proof;
            
                _permitService.UpsertPermit(existingPermit);

                var response = new PermitResponse(
                    existingPermit.IdPermit,
                    existingPermit.IdStudent,
                    existingPermit.IdProfessorInCourse,
                    existingPermit.Motive,
                    existingPermit.AbsenceDate,
                    existingPermit.Proof,
                    existingPermit.CreatedAt,
                    existingPermit.LastTimeModified
                    );
                return Ok(response );
            }

            else
            {
                var newPermit = new Permit(
                    Guid.NewGuid(),
                    request.IdStudent,
                    request.IdProfessorInCourse,
                    request.Motive,
                    request.AbsenceDate,
                    request.Proof,
                    DateTime.UtcNow,
                    DateTime.UtcNow
                    );
                _permitService.CreatePermit(newPermit);

                var response = new PermitResponse(
                    newPermit.IdPermit,
                    newPermit.IdStudent,
                    newPermit.IdProfessorInCourse,
                    newPermit.Motive,
                    newPermit.AbsenceDate,
                    newPermit.Proof,
                    newPermit.CreatedAt,
                    newPermit.LastTimeModified
                    );
                return CreatedAtAction(
                    actionName: nameof(GetPermit),
                    routeValues: new { id = newPermit.IdPermit },
                    value: response);
            }


        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePermit(Guid id)
        {
            Permit permit = _permitService.GetPermit(id);
            if( permit == null )
            {
                return NotFound();
            }
            _permitService.DeletePermit(id);
            return NoContent();
        }
    }
}
