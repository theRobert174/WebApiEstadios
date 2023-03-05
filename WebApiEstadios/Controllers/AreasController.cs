using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/areas")]
    public class AreasController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public AreasController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public async Task< ActionResult <List<Area>>> Get()
        {
            return await dbContext.Areas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task< ActionResult< Area>> GetById(int id)
        {
            return await dbContext.Areas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task< ActionResult> Post(Area area)
        {
            var existEstadium = await dbContext.Estadios.AnyAsync(x => x.Id == area.EstadioId);
            if (!existEstadium)
            {
                return BadRequest($"No existe el estadio con el id: {area.EstadioId}");
            }

            dbContext.Add(area);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task< ActionResult> Put(Area area, int id)
        {
            var exist = await dbContext.Areas.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound("El area especificada no existe");
            }

            if(area.Id != id)
            {
                return BadRequest("El id del area no coincide con el proporcionado en la URL.");
            }

            dbContext.Update(area);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task< ActionResult> Delete(int id)
        {
            var exist = await dbContext.Areas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El area especificada no existe");
            }

            dbContext.Remove(new Area { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
