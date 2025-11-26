using Microsoft.AspNetCore.Mvc;
using SalonAPI.Entities;

namespace SalonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "שרה כהן", Phone = "050-1234567", Email = "sarah@example.com", IsActive = true },
            new Customer { Id = 2, Name = "רחל לוי", Phone = "052-9876543", IsActive = true }
        };

        // GET: api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get([FromQuery] string? query)
        {
            if (string.IsNullOrEmpty(query))
                return Ok(customers);

            var filtered = customers.Where(c =>
                c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(query)).ToList();

            return Ok(filtered);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;
            customers.Add(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            var existing = customers.FirstOrDefault(c => c.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = customer.Name;
            existing.Phone = customer.Phone;
            existing.Email = customer.Email;
            existing.Notes = customer.Notes;
            existing.IsActive = customer.IsActive;

            return NoContent();
        }

        // PUT: api/customers/5/status
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] bool isActive)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customer.IsActive = isActive;
            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            customers.Remove(customer);
            return NoContent();
        }
    }
}