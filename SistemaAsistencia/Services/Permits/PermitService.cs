using SistemaAsistencia.Models;

namespace SistemaAsistencia.Services.Permits
{
    /*
     * Autor: César Gilberto Solares Castellanos
     * Fecha: 01/05/2024
     * Descripción: Logica para los servicios de permisos.
     */
    public class PermitService :IPermitService
    {
        //Instancia para la comunicacion de la base de datos
        private readonly SystemDatabaseContext _dbContext;
        public PermitService(SystemDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePermit(Permit permit)
        {
            _dbContext.Permits.Add(permit);
            _dbContext.SaveChanges();
        }

        public Permit GetPermit(Guid id)
        {
            return _dbContext.Permits.FirstOrDefault(c => c.IdPermit == id);
        }

        public void UpsertPermit(Permit permit)
        {
            var existingPermit = _dbContext.Permits.FirstOrDefault(c => c.IdPermit == permit.IdPermit);
            if (existingPermit != null)
            {
                existingPermit.IdStudent = permit.IdStudent;
                existingPermit.IdProfessorInCourse = permit.IdProfessorInCourse;
                existingPermit.Motive = permit.Motive;
                existingPermit.AbsenceDate = permit.AbsenceDate;
                existingPermit.Proof = permit.Proof;
                existingPermit.LastTimeModified = DateTime.UtcNow;
            }
            else
            {
                _dbContext.Permits.Add(permit);
            }

            _dbContext.SaveChanges(true);
        }

        public void DeletePermit(Guid id)
        {
            var permitToDelete = _dbContext.Permits.FirstOrDefault(p => p.IdPermit == id); 

            if(permitToDelete != null)
            {
                _dbContext.Permits.Remove(permitToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
