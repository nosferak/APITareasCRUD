using Microsoft.EntityFrameworkCore;
using TareasCRUD.Core.Interfaces.Repository;
using TareasCRUD.Core.Interfaces;
using TareasCRUD.Infrastructure.Data;
using TareasCRUD.Infrastructure.Repositories;
using TareasCRUD.Core.Interfaces.Services;
using TareasCRUD.Service;

namespace TareasCRUD.WebApi
{
    //public class Startup
    //{
    //}

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            //Para desplegar Docker o ejecutar en IIS
            string ConnectionString = Configuration.GetConnectionString("Default"); //?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(ConnectionString,
            x => x.MigrationsAssembly("TareasCRUD.Infrastructure")));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped(typeof(ITareasRepository), typeof(TareaRepository));
            //services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));

            services.AddScoped(typeof(ITareasService), typeof(TareaService));
            //services.AddScoped(typeof(IUsuarioService), typeof(ActivoService));
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            // ...
        }
    }
}
