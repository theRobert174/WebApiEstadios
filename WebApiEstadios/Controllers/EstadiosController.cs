﻿using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("/estadios")]
    public class EstadiosController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Estadio>> Get()
        {
            return new List<Estadio>() 
            {
                new Estadio{ Id = 1,Name="Estadio Universitario", Owner="UANL", Coords="San Nicolas de los Garza", ParkingCapacity=500, TotalSeats=41886},
                new Estadio{ Id = 2,Name="Estadio BBVA", Owner = "FEMSA", Coords="Guadalupe", ParkingCapacity=200, TotalSeats=51348},
                new Estadio{ Id = 3,Name="Estadio Azteca", Owner="Grupo Televisa", Coords="Ciudad de Mexico", ParkingCapacity=600, TotalSeats=87000}
            };
        }
    }
}