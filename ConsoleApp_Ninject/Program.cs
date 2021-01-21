using System;
using System.Threading.Tasks;

using Data;
using Servicios;
using Microsoft.EntityFrameworkCore;

using Ninject;
using Ninject.Modules;

namespace ConsoleApp_Ninject
{
    public class ScopeObject { }

    public static class ProcessingScope
    {
        public static ScopeObject Current { get; set; }
    }

    class Program
    {
        static IKernel kernel;

        static void Setup()
        {
            kernel = new StandardKernel();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(@"Data source = 192.168.1.70; Initial Catalog = PruebasArquitectura; Integrated Security = False; User Id = usuario; Password = 1234;")
                .Options;


            kernel.Bind<DbContextOptions<ApplicationDbContext>>().ToConstant(contextOptions);

                //mismo dbcontext para TODAS las peticiones - Singleton
                //kernel.Bind<ApplicationDbContext>().ToSelf().InSingletonScope();

                //distinto dbcontext para TODAS las peticiones
                //kernel.Bind<ApplicationDbContext>().ToSelf().InTransientScope();

                //mismo dbcontext para TODAS las peticiones dentro de un hilo de ejecucion
                //kernel.Bind<ApplicationDbContext>().ToSelf().InThreadScope();

                // scope personalizado
                // con el scope, se puede personalizar. pero hay q indicar en cada caso el alcance del binding
                //asi conseguimos que si dos servicios enlazados usan el dbcontext, este, sea el mismo                
                kernel.Bind<ApplicationDbContext>().ToSelf().InScope(x => ProcessingScope.Current);


            kernel.Bind<IClientesServicio>().To<ClientesServicio>();
            kernel.Bind<IAutorizacionServicio>().To<AutorizacionServicio>();

        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Programa de consola. Inicio");

            Setup();

            try
            {
                var ScopeA = new ScopeObject();
                ProcessingScope.Current = ScopeA; //indicamos el scope personalizado para cada servicio, antes de crearlo con ninject
                var svr = kernel.Get<IClientesServicio>();
                var resultado = svr.ObtenerCliente(1);

                Console.WriteLine("Datos recuperados servicio 1");
                Console.WriteLine("Firma");
                Console.WriteLine(resultado.Firma);

                var ScopeB = new ScopeObject();
                ProcessingScope.Current = ScopeB; //distinto scope
                var svr2 = kernel.Get<IClientesServicio>();
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
