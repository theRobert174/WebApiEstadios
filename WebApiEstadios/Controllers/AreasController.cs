using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/areas")]
    public class AreasController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Area>> Get()
        {
            return new List<Area>()
            {
                new Area{ Id = 1,Name="VIP", Capacity=100, Available=70, Taken=20 },
                new Area{ Id = 2,Name="East", Capacity=500, Available=120, Taken=380 },
                new Area{ Id = 3,Name="Staff", Capacity=150, Available=20, Taken=130 }
            };
        }
    }
}
