using Microsoft.EntityFrameworkCore;
using System;

using Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace Servicios
{
    public class ClientesServicio : IClientesServicio
    {
        public ApplicationDbContext _Dbcontext { get; }

        public ClientesServicio(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }               

        public ClienteDominio ObtenerCliente(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteDominio>());
            var mapper = new Mapper(config);

            var query = _Dbcontext.Clientes.Where(x => x.Id == id).FirstOrDefault();

            var dominio = mapper.Map<ClienteDominio>(query);

            return dominio;
        }

    }
}
