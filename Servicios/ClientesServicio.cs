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

        private MapperConfiguration configr_DB2Dominio;
        private MapperConfiguration configr_Dominio2DB;
        private Mapper mapper_DB2Dominio;
        private Mapper mapper_Dominio2DB;

        public ClientesServicio(ApplicationDbContext dbcontext)
        {
            _Dbcontext = dbcontext;

            //TODO: configuracion de automapper. sacar a clase externa y pasar en constructor
            configr_DB2Dominio = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteDominio>()); 
            mapper_DB2Dominio = new Mapper(configr_DB2Dominio);

            configr_Dominio2DB = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDominio, Cliente>());
            mapper_Dominio2DB = new Mapper(configr_Dominio2DB);

        }               

        public ClienteDominio ObtenerCliente(int id)
        {                     
            var query = _Dbcontext.Clientes.Where(x => x.Id == id).FirstOrDefault();

            var dominio = mapper_DB2Dominio.Map<ClienteDominio>(query);

            return dominio;
        }

        public ClienteDominio GuardarCliente(ClienteDominio cliente)
        {
            var db = mapper_Dominio2DB.Map<Cliente>(cliente);

            _Dbcontext.Clientes.Add(db);

            _Dbcontext.SaveChanges();

            return ObtenerCliente(cliente.Id);
        }
    }
}
