using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/estadiosTypes")]
    public class EstadioTypesController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EstadioType>> Get()
        {
            return new List<EstadioType>()
            {
                new EstadioType{ Id = 1, Type="Futbol"},
                new EstadioType{ Id = 2, Type="Baseball"},
                new EstadioType{ Id = 3, Type="Olympico"}
            };
        }
    }
}
