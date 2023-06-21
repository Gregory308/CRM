using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomerController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public CustomerController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customer = await _context.Customer.ToListAsync();
            return Ok(customer);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound("Nie znaleziono klienta");
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(Customer customerNew)
        {

            if (customerNew != null)
            {
                _context.Customer.Add(customerNew);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound("Nie dodano klienta");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                _context.Customer.Remove(customer);
                _context.SaveChanges();
                return Ok("Klient został usunięty");
            }

            return NotFound("Nie znaleziono klienta");
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateCustomer([FromRoute] int id, Customer customerUpdated)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);

            if (customer != null)
            {
                customer.Name = customerUpdated.Name;
                customer.LastName = customerUpdated.LastName;
                customer.Email = customerUpdated.Email;
                customer.Login = customerUpdated.Login;
                customer.Password = customerUpdated.Password;
                _context.SaveChanges();
                return Ok("Klient został zmodyfikowany");
            }

            return NotFound("Klient nie został zmodyfikowany");
        }

        [HttpGet]
        [Route("customerNotifications/{id:int}")]
        public async Task<ActionResult> GetCustomerNotifications([FromRoute] int id)
        {
            var notificationPerCustomer = _context.Notifications.Where(d => d.CustomerId == id).ToList();
            if (notificationPerCustomer != null)
            {
                return Ok(notificationPerCustomer);
            }

            return NotFound("Nie znaleziono klienta");
        }
    }
}
