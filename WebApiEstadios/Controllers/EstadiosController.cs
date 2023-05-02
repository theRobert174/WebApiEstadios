using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/estadios")]
    public class EstadiosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EstadiosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task< ActionResult< List<Estadio>>> Get()
        {
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
