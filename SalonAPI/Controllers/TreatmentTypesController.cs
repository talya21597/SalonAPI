using Microsoft.AspNetCore.Mvc;
using SalonAPI.Entities;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentTypesController : ControllerBase
    {
        private static List<TreatmentType> treatmentTypes = new List<TreatmentType>
        {
            new TreatmentType { Id = 1, Name = "תספורת גברים", DurationMinutes = 30, Price = 80 },
            new TreatmentType { Id = 2, Name = "תספורת נשים", DurationMinutes = 60, Price = 150 },
            new TreatmentType { Id = 3, Name = "צביעה", DurationMinutes = 120, Price = 350 },
            new TreatmentType { Id = 4, Name = "פן", DurationMinutes = 45, Price = 120 }
        };

        // GET: api/treatmenttypes
        [HttpGet]
        public ActionResult<IEnumerable<TreatmentType>> Get()
        {
            return Ok(treatmentTypes);
        }

        // GET: api/treatmenttypes/5
        [HttpGet("{id}")]
        public ActionResult<TreatmentType> Get(int id)
        {
            var treatment = treatmentTypes.FirstOrDefault(t => t.Id == id);
            if (treatment == null)
                return NotFound();

            return Ok(treatment);
        }

        // POST: api/treatmenttypes
        [HttpPost]
        public ActionResult<TreatmentType> Post([FromBody] TreatmentType treatmentType)
        {
            treatmentType.Id = treatmentTypes.Any() ? treatmentTypes.Max(t => t.Id) + 1 : 1;
            treatmentTypes.Add(treatmentType);
            return CreatedAtAction(nameof(Get), new { id = treatmentType.Id }, treatmentType);
        }

        // PUT: api/treatmenttypes/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TreatmentType treatmentType)
        {
            var existing = treatmentTypes.FirstOrDefault(t => t.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = treatmentType.Name;
            existing.DurationMinutes = treatmentType.DurationMinutes;
            existing.Price = treatmentType.Price;

            return NoContent();
        }

        // DELETE: api/treatmenttypes/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var treatment = treatmentTypes.FirstOrDefault(t => t.Id == id);
            if (treatment == null)
                return NotFound();

            treatmentTypes.Remove(treatment);
            return NoContent();
        }
    }
}