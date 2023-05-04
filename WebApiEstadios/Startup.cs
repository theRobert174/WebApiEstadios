using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using WebApiEstadios.Middlewares;
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            #region Middleware

            //Un Middleware se caracteriza por un "Use"

            //1)Middleware
            //"Use" permite agregar un proceso sin interrumpir el flujo como "Run"
            /*app.Use(async (context, siguiente) =>
            {
                using (var ms = new MemoryStream())
                {
                    //Se asigna el body del response en una variable y se le da el valor de memoryStream
                    var originalBody = context.Response.Body;
                    context.Response.Body = ms;

                    //Permite continuar con la siguiente linea
                    await siguiente.Invoke();

                    //Guardamos lo que le respondemos al cliente en el string
                    ms.Seek(0, SeekOrigin.Begin);

                    string response = new StreamReader(ms).ReadToEnd();
                    ms.Seek(0, SeekOrigin.Begin);

                    //Leemos el stream y lo dejamos como estaba
                    await ms.CopyToAsync(originalBody);
                    context.Response.Body = originalBody;

                    logger.LogInformation(response);
                }
            });*/

            //2)Middleware
            //Metodo para usar la clase propia creada de middleware
            //app.UseMiddleware<ResponseHttpMiddleware>();

            //3)Middleware
            //Metodo para utilizar la middleware sin exponer la clase
            app.UseResponseHttpMiddleware();

            /*
                Atrapa todas las peticiones http que mandemos y retorna un string 
                Para detener todos los otros middleware segun una ruta especifica se utiliza Map, al usar Map permite que en lugar de ejecutar linealmente
                podemos agregar rutas especificas para nuestro middleware
            */
            app.Map("/maping", app =>
            {
                //Usar solo "Run" rompe con el fujo del codigo, pero si se usa dentro de un "Map" sigue con las demas peticiones
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Interceptando las peticiones");
                });
            });

            #endregion

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
