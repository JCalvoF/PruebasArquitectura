namespace Servicios
{
    public interface IClientesServicio
    {
        ClienteDominio GuardarCliente(ClienteDominio cliente);
        ClienteDominio ObtenerCliente(int id);
    }
}
