using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/estadios")]
    public class EstadiosController : ControllerBase
    {
        /*private readonly ApplicationDbContext dbContext;

        public EstadiosController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }*/

        [HttpGet]
        public ActionResult <List<Estadio>> Get()
        {
            return new List<Estadio>()
            {
                new Estadio
                {
                    Id = 1,
                    Name="Estadio Universitario",
                    Owner="UANL",
                    Coords="San Nicolas de los Garza",
                    ParkingCapacity=500,
                    TotalSeats=41886,
                    Areas = new List<Area>()
                    {
                        new Area { Id = 1, Name="VIP", Capacity=100, Available=70, Taken=20 },
                        new Area { Id = 2,Name="East", Capacity=500, Available=120, Taken=380 },
                        new Area { Id = 3,Name="Staff", Capacity=150, Available=20, Taken=130 }
                    },
                    EstadioType = new EstadioType { Id = 1, Type = "Fútbol" }
                },
                new Estadio
                { 
                    Id = 2,
                    Name="Estadio BBVA", 
                    Owner = "FEMSA", 
                    Coords="Guadalupe", 
                    ParkingCapacity=200, 
                    TotalSeats=51348,
                    Areas = new List<Area>()
                    {
                        new Area { Id = 1, Name="VIP", Capacity=100, Available=70, Taken=20 },
                        new Area { Id = 2,Name="East", Capacity=500, Available=120, Taken=380 },
                        new Area { Id = 3,Name="Staff", Capacity=150, Available=20, Taken=130 }
                    },
                    EstadioType = new EstadioType { Id = 1, Type = "Fútbol" }
                },
                new Estadio
                { 
                    Id = 3,
                    Name="Estadio Azteca", 
                    Owner="Grupo Televisa", 
                    Coords="Ciudad de Mexico", 
                    ParkingCapacity=600, 
                    TotalSeats=87000,
                    Areas = new List<Area>()
                    {
                        new Area { Id = 1, Name="VIP", Capacity=100, Available=70, Taken=20 },
                        new Area { Id = 2,Name="East", Capacity=500, Available=120, Taken=380 },
                        new Area { Id = 3,Name="Staff", Capacity=150, Available=20, Taken=130 }
                    },
                    EstadioType = new EstadioType { Id = 1, Type = "Fútbol" }
                }
            };
        }

        /*[HttpGet("first")]
        public async Task<ActionResult<Estadio>> FirstEstadium()
        {
            return await dbContext.Estadios.FirstOrDefaultAsync();
        }*/
    }
}
