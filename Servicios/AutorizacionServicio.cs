using Microsoft.EntityFrameworkCore;
using System;

using Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;

namespace Servicios
{

    public class AutorizacionServicio : IAutorizacionServicio
    { 

        public Guid guid { get; private set; }

        public ApplicationDbContext Dbcontext { get; }

        public AutorizacionServicio(ApplicationDbContext dbcontext)
        {
            guid = Guid.NewGuid();
            Dbcontext = dbcontext;
        }

        public Guid ObtenerGuid_Servicio()
        {
            return guid;
        }

        public Guid ObtenerGuid_DBContext()
        {
            return Dbcontext.guid;
        }

        public bool EstaAutorizado()
        {
            return true;
        }
    }
}
