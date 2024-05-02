using SistemaAsistencia.Contracts.SistemaAsistencia.Permit;
using SistemaAsistencia.Models;
/*
 * Autor: César Gilberto solares Castellanos
 * Fecha: 01/05/2024 20:42PM
 * Descripcion: Interface para el servicio de los permisos
 */
namespace SistemaAsistencia.Services.Permits
{
    public interface IPermitService
    {
        public void CreatePermit(Permit permit);
        Permit GetPermit(Guid id);
        void UpsertPermit(Permit permit);
        void DeletePermit(Guid id);

    }
}
