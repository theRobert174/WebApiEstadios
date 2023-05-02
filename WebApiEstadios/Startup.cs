using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

using WebApiEstadios.Services;

namespace WebApiEstadios
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
            });

            #region Mis Servicios

            services.AddTransient<IService, ServiceA>();
            /*
                Transient da nueva instancia de la clase declarada, sirve para funciones que ejecutan un funcionalidad y listo, 
                sin tener que mantener informacion que sera utlizada en otros lugares.              
            */
            services.AddTransient<ServiceTransient>();
            /*
                Scoped el tiempo de vida de la clase declarada aumenta, sin embargo, 
                Scoped da diferentes instancias de acuerdo a cada quien que mande la solicitud
                es decir Rodrigo tiene su instancia y Estadio otra
            */
            services.AddScoped<ServiceScoped>();
            /*
                Singleton se tiene la misma instancia siempre para todos los usuarios en todos los dias,
                todo usuario que haga una peticion va a tener la misma informacion compartida entre todos
            */
            services.AddSingleton<ServiceSingleton>();

            #endregion

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIEstadios", Version="v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
