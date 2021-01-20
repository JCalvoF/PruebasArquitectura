using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Data;
using Servicios;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        public IClientesServicio Servicioclientes { get; }

        //inyectamos el servicio a usar por el controlador.
        public ClientesController(IClientesServicio _servicioclientes)
        {
            Servicioclientes = _servicioclientes;
        }

        // GET: api/<ClientesControllercs>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientesControllercs>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var cliente = Servicioclientes.ObtenerCliente(id);
            return cliente.NombreCompleto;
        }

        // POST api/<ClientesControllercs>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ClientesControllercs>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesControllercs>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
