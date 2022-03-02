using Microsoft.AspNetCore.Mvc;
using NotablePhysicianServer.Models;
using NotablePhysicianServer.Dtos;
using System;

namespace NotablePhysicianServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicianController : ControllerBase
    {
        private static readonly List<Physician> Physicians = new List<Physician>
        {
            new Physician("Louis Beckham", Guid.NewGuid()),
            new Physician("Tyler Herro", Guid.NewGuid()),
            new Physician("Temetrius Jamel Morant", Guid.NewGuid())
        };

        private readonly ILogger<PhysicianController> _logger;

        public PhysicianController(ILogger<PhysicianController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/all", Name = "GetPhysicianList")]
        public IActionResult GetPhysicianList()
        {
            Console.WriteLine(Physicians);
            return Ok(Physicians);
        }
    }
}