using Microsoft.AspNetCore.Mvc;
using SalonAPI.Entities;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairdressersController : ControllerBase
    {
        private static List<Hairdresser> hairdressers = new List<Hairdresser>
        {
            new Hairdresser { Id = 1, Name = "מיכל אברהם", Phone = "054-1111111", Specialization = "תספורות", IsActive = true },
            new Hairdresser { Id = 2, Name = "דנה יוסף", Phone = "053-2222222", Specialization = "צביעות", IsActive = true }
        };

        // GET: api/hairdressers
        [HttpGet]
        public ActionResult<IEnumerable<Hairdresser>> Get()
        {
            return Ok(hairdressers);
        }

        // GET: api/hairdressers/5
        [HttpGet("{id}")]
        public ActionResult<Hairdresser> Get(int id)
        {
            var hairdresser = hairdressers.FirstOrDefault(h => h.Id == id);
            if (hairdresser == null)
                return NotFound();

            return Ok(hairdresser);
        }

        // POST: api/hairdressers
        [HttpPost]
        public ActionResult<Hairdresser> Post([FromBody] Hairdresser hairdresser)
        {
            hairdresser.Id = hairdressers.Any() ? hairdressers.Max(h => h.Id) + 1 : 1;
            hairdressers.Add(hairdresser);
            return CreatedAtAction(nameof(Get), new { id = hairdresser.Id }, hairdresser);
        }

        // PUT: api/hairdressers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hairdresser hairdresser)
        {
            var existing = hairdressers.FirstOrDefault(h => h.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = hairdresser.Name;
            existing.Phone = hairdresser.Phone;
            existing.Specialization = hairdresser.Specialization;
            existing.IsActive = hairdresser.IsActive;

            return NoContent();
        }

        // PUT: api/hairdressers/5/status
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] bool isActive)
        {
            var hairdresser = hairdressers.FirstOrDefault(h => h.Id == id);
            if (hairdresser == null)
                return NotFound();

            hairdresser.IsActive = isActive;
            return NoContent();
        }
    }
}