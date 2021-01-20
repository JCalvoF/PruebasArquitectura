using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios
{

    public class AutorizacionServicio : IAutorizacionServicio
    {
        public bool EstaAutorizado()
        {
            return true;
        }
    }
}
