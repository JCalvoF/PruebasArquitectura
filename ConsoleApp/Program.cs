using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Data;
using Servicios;

using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ConsoleApp
{
    class Program
    {
        static IUnityContainer container;

        static void Setup()
        {
            
            
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Data source = 192.168.1.70; Initial Catalog = PruebasArquitectura; Integrated Security = False; User Id = usuario; Password = 1234;")
                .Options;
            


            //contenedor IoC
            container = new UnityContainer();


            //registro las opciones de creacion del dbcontext como intancia. siempre las mismas
            container.RegisterInstance<DbContextOptions<ApplicationDbContext>>(contextOptions);

            //genera un dbcontext por cada llamada jerarquica, es decir, si varios servicios usan el mismo dbcontext, se pasa el mismo para todos
            container.RegisterType<ApplicationDbContext, ApplicationDbContext>(new PerResolveLifetimeManager());

            //un nuevo dbcontext para dada llamada. siempre distinto.
            //container.RegisterType<DbContext, ApplicationDbContext>(TypeLifetime.PerResolve);

            //mismo dbcontext para TODA la aplicacion. siempre la misma instancia
            //ApplicationDbContext context;
            //context = new ApplicationDbContext(contextOptions);
            //container.RegisterInstance<ApplicationDbContext>(context);
            //o registrado como singleton
            //container.RegisterType<ApplicationDbContext, ApplicationDbContext>(new SingletonLifetimeManager());

            //registro de tipos para los servicios.           
            container.RegisterType<IAutorizacionServicio, AutorizacionServicio>(new PerResolveLifetimeManager());
            container.RegisterType<IClientesServicio, ClientesServicio>(new PerResolveLifetimeManager());

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Programa de consola. Inicio");
            
            Setup();            

            try
            {
                var svr = container.Resolve<IClientesServicio>();
                var resultado = svr.ObtenerCliente(1);

                Console.WriteLine("Datos recuperados servicio 1");
                Console.WriteLine("Firma");
                Console.WriteLine(resultado.Firma);

                var svr2 = container.Resolve<IClientesServicio>();
                var resultado2 = svr2.ObtenerCliente(1);

                Console.WriteLine("Datos recuperados servicio 2");
                Console.WriteLine("Firma");
                Console.WriteLine(resultado2.Firma);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine(ex.Message);
            }
            //traemos el cliente, usando el servicio


            Console.WriteLine("Fin. pulse una tecla para cerrar");
            Console.ReadKey();
        }


    }
}
