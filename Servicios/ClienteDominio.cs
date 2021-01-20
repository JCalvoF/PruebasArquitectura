namespace Servicios
{
    /// <summary>
    /// clase de dominio para clientes
    /// </summary>
    public class ClienteDominio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string NombreCompleto { get { return string.Format("{0}-{1}", Id, Nombre); } }
    }
}
