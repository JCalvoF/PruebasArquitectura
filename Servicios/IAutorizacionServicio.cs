using System;

namespace Servicios
{
    public interface IAutorizacionServicio
    {
        bool EstaAutorizado();
        Guid ObtenerGuid_DBContext();
        Guid ObtenerGuid_Servicio();
    }
}
