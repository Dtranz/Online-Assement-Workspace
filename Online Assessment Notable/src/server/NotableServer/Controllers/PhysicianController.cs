using Microsoft.AspNetCore.Mvc;
using NotableServer.Models;
using NotableServer.Dtos;
using System;

namespace NotableServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhysicianController : ControllerBase
    {
        private List<Physician> Physicians;
        private Dictionary<int, List<ScheduledPatient>> PatientLookup;

    private readonly ILogger<PhysicianController> _logger;

        public PhysicianController(ILogger<PhysicianController> logger)
        {
            _logger = logger;
            Physicians = new List<Physician>
            {
                    new Physician("Kevin Durant", 1),
                    new Physician("Tyler Herro", 2),
                    new Physician("Temetrius Jamel Morant", 3)
            };
            PatientLookup = new Dictionary<int, List<ScheduledPatient>>();

            PatientLookup.Add(1, new List<ScheduledPatient>());
            PatientLookup.Add(2, new List<ScheduledPatient>());
            PatientLookup.Add(3, new List<ScheduledPatient>());

            PatientLookup[1].Add(new ScheduledPatient(Guid.NewGuid(), "9AM", "LeBron James", VisitType.NewPatient));
            PatientLookup[1].Add(new ScheduledPatient(Guid.NewGuid(), "10AM", "Kyrie Irving", VisitType.FollowUp));
            PatientLookup[1].Add(new ScheduledPatient(Guid.NewGuid(), "11AM", "James Harden", VisitType.FollowUp));


            PatientLookup[2].Add(new ScheduledPatient(Guid.NewGuid(), "9:30AM", "Loic Bruni", VisitType.NewPatient));
            PatientLookup[2].Add(new ScheduledPatient(Guid.NewGuid(), "12:30PM", "Gee Atherton", VisitType.FollowUp));
            PatientLookup[2].Add(new ScheduledPatient(Guid.NewGuid(), "2PM", "Richie Rude", VisitType.FollowUp));

            PatientLookup[3].Add(new ScheduledPatient(Guid.NewGuid(), "8AM", "Sean Paul", VisitType.FollowUp));
            PatientLookup[3].Add(new ScheduledPatient(Guid.NewGuid(), "11:30AM", "Rick Owens", VisitType.FollowUp));
            PatientLookup[3].Add(new ScheduledPatient(Guid.NewGuid(), "12:20pm", "Gabriel Valdez", VisitType.NewPatient));
        }

        [HttpGet("/all", Name = "GetPhysicianList")]
        public IActionResult GetPhysicianList()
        {
            Console.WriteLine(Physicians);
            return Ok(Physicians);
        }

        [HttpGet("/{id}", Name = "GetSchedule")]
        public IActionResult GetSchedule(int id)
        {
            List<ScheduledPatient> value;
            if (PatientLookup.TryGetValue(id, out value))
            {
                return Ok(value);
            }
            return NotFound();
        }
    }
}