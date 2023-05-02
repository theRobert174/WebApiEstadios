using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

using WebApiEstadios.Services;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/estadios")]
    public class EstadiosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        private readonly IService service;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;
        private readonly ServiceTransient serviceTransient;
        private readonly ILogger<EstadiosController> logger;

        //Contructor
        public EstadiosController( ApplicationDbContext context, IService service, ServiceScoped serviceScoped, 
            ServiceSingleton serviceSingleton, ServiceTransient serviceTransient, ILogger<EstadiosController> logger )
        {
            this.dbContext = context;

            this.service = service;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
            this.serviceTransient = serviceTransient;
            this.logger = logger;
        }

        [HttpGet("GUID")]
        public ActionResult ObtenerGuid()
        {
            return Ok(new
            {
                EstadiosControllerScoped = serviceScoped.guid,
                ServiceA_Scoped = service.GetScoped(),
                EstadiosControllerSingleton = serviceSingleton.guid,
                ServiceA_Singleton = service.GetSingleton(),
                EstadiosControllerTransient = serviceTransient.guid,
                ServiceA_Transient = service.GetTransient(),
            });
        }

        //Endpoints-------------------------------------------------------
        [HttpGet]
        public async Task< ActionResult< List<Estadio>>> Get()
        {
            /*
                Niveles de logs
                -Critical
                -Error
                -Warning
                -Information
                -Debug
                -Trace
            */
            logger.LogInformation("Obteniendo listado de Estadios");
            logger.LogWarning("Solicitud de solo lectura de Informacion en DB");
            logger.LogWarning((string)service.ExecuteJob());

            return await dbContext.Estadios.Include(x => x.Areas).ToListAsync();
        }

        [HttpGet("primero")]
        public async Task<ActionResult<Estadio>> PrimerEstadio()
        {
            return await dbContext.Estadios.Include(x => x.Areas).FirstOrDefaultAsync();
        }

        //[HttpGet("{id:int}")]
        [HttpGet("get")]
        public async Task<ActionResult<Estadio>> GetById([FromQuery] int id)
        {
            return await dbContext.Estadios.Include(x => x.Areas).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estadio estadio)
        {
            dbContext.Add(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task< ActionResult> Put(Estadio estadio, int id)
        {
            if(estadio.Id != id) 
            {
                return BadRequest("El id del estadio no coincide con el proporcionado en el URL.");
            }

            var exist = await dbContext.Estadios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            dbContext.Update(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task< ActionResult> Delete(int id)
        {
            var exist = await dbContext.Estadios.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Estadio()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
