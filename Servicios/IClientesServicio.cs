using System;

namespace Servicios
{
    public interface IClientesServicio
    {
        Guid ObtenerGuid_DBContext();
        Guid ObtenerGuid_Servicio();

        ClienteDominio GuardarCliente(ClienteDominio cliente);
        ClienteDominio ObtenerCliente(int id);
    }
}
