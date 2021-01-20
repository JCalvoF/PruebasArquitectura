using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


using Data;
using Microsoft.EntityFrameworkCore;

namespace Servicios
{
    //public static class bootstrap
    //{

    //    private static ApplicationDbContext ctx;

    //    public static void Setup()
    //    {
    //        //ctx = new ApplicationDbContext(
    //        //    options => options.UseSqlServer(
    //        //        Configuration.GetConnectionString("defaultConnection"))
    //        //    );
    //    }
    //}

    //public class Startup
    //{
    //    public IConfiguration Configuration { get; }

    //    public Startup(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddDbContext<ApplicationDbContext>(
    //            options => options.UseSqlServer(
    //                Configuration.GetConnectionString("Data source=192.168.1.70;Initial Catalog=PruebasArquitectura;Integrated Security=False;User Id=usuario;Password=1234;"))

    //        );

    //    }
    //}
}
