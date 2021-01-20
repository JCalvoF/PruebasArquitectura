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
        public Guid guid { get; private set; }

        public ApplicationDbContext _Dbcontext { get; }
        public IAutorizacionServicio Auth { get; }

        private MapperConfiguration configr_DB2Dominio;
        private MapperConfiguration configr_Dominio2DB;
        private Mapper mapper_DB2Dominio;
        private Mapper mapper_Dominio2DB;

        public ClientesServicio(
            ApplicationDbContext dbcontext,
            IAutorizacionServicio auth)
        {
            _Dbcontext = dbcontext;
            Auth = auth;

            //TODO: configuracion de automapper. sacar a clase externa y pasar en constructor
            configr_DB2Dominio = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteDominio>()); 
            mapper_DB2Dominio = new Mapper(configr_DB2Dominio);

            configr_Dominio2DB = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDominio, Cliente>());
            mapper_Dominio2DB = new Mapper(configr_Dominio2DB);

            guid = Guid.NewGuid();
        }               



        public ClienteDominio ObtenerCliente(int id)
        {                     
            var query = _Dbcontext.Clientes.Where(x => x.Id == id).FirstOrDefault();

            var dominio = mapper_DB2Dominio.Map<ClienteDominio>(query);

            dominio.Autorizado = Auth.EstaAutorizado();

            dominio.guidcompleto = string.Format("DbContext:{0}, Servicio:{1}, DbContext Auth:{2}, Servicio Auth:{3}", 
                _Dbcontext.guid,
                guid,
                Auth.ObtenerGuid_DBContext(),
                Auth.ObtenerGuid_Servicio()
                );

            return dominio;
        }

        public ClienteDominio GuardarCliente(ClienteDominio cliente)
        {
            var db = mapper_Dominio2DB.Map<Cliente>(cliente);

            _Dbcontext.Clientes.Add(db);

            _Dbcontext.SaveChanges();

            var rto = ObtenerCliente(cliente.Id);

            rto.guidcompleto = string.Format("DbContext:{0}, Servicio:{1}, DbContext Auth:{2}, Servicio Auth:{3}",
                _Dbcontext.guid,
                guid,
                Auth.ObtenerGuid_DBContext(),
                Auth.ObtenerGuid_Servicio()
                );

            return rto;
        }
    }
}
