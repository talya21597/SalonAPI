using Microsoft.AspNetCore.Mvc;
using SalonAPI.Entities;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private static List<Appointment> appointments = new List<Appointment>
        {
            new Appointment
            {
                Id = 1,
                CustomerId = 1,
                HairdresserId = 1,
                TreatmentTypeId = 1,
                Date = DateTime.Today.AddDays(1),
                Time = new TimeSpan(10, 0, 0),
                Status = AppointmentStatus.Confirmed
            }
        };

        // GET: api/appointments
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> Get([FromQuery] DateTime? date, [FromQuery] int? hairdresserId)
        {
            var filtered = appointments.AsEnumerable();

            if (date.HasValue)
                filtered = filtered.Where(a => a.Date.Date == date.Value.Date);

            if (hairdresserId.HasValue)
                filtered = filtered.Where(a => a.HairdresserId == hairdresserId.Value);

            return Ok(filtered.ToList());
        }

        // GET: api/appointments/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        // POST: api/appointments
        [HttpPost]
        public ActionResult<Appointment> Post([FromBody] Appointment appointment)
        {
            appointment.Id = appointments.Any() ? appointments.Max(a => a.Id) + 1 : 1;
            appointments.Add(appointment);
            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        // PUT: api/appointments/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Appointment appointment)
        {
            var existing = appointments.FirstOrDefault(a => a.Id == id);
            if (existing == null)
                return NotFound();

            existing.CustomerId = appointment.CustomerId;
            existing.HairdresserId = appointment.HairdresserId;
            existing.TreatmentTypeId = appointment.TreatmentTypeId;
            existing.Date = appointment.Date;
            existing.Time = appointment.Time;
            existing.Status = appointment.Status;
            existing.Notes = appointment.Notes;

            return NoContent();
        }

        // PUT: api/appointments/5/status
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] AppointmentStatus status)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            appointment.Status = status;
            return NoContent();
        }

        // DELETE: api/appointments/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var appointment = appointments.FirstOrDefault(a => a.Id == id);
            if (appointment == null)
                return NotFound();

            appointments.Remove(appointment);
            return NoContent();
        }

        // GET: api/appointments/available
        [HttpGet("available")]
        public ActionResult<IEnumerable<TimeSpan>> GetAvailableSlots([FromQuery] DateTime date, [FromQuery] int hairdresserId)
        {
            var bookedTimes = appointments
                .Where(a => a.Date.Date == date.Date && a.HairdresserId == hairdresserId)
                .Select(a => a.Time)
                .ToList();

            var availableSlots = new List<TimeSpan>();
            for (int hour = 9; hour <= 18; hour++)
            {
                var slot = new TimeSpan(hour, 0, 0);
                if (!bookedTimes.Contains(slot))
                    availableSlots.Add(slot);
            }

            return Ok(availableSlots);
        }
    }
}