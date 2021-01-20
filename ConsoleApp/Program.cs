using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa de consola. Inicio");

            //var services = new ServiceCollection();
            //var connection = @"cadena de conexion";
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));



            Console.WriteLine("Fin. pulse una tecla para cerrar");
            Console.ReadKey();
        }


    }
}
