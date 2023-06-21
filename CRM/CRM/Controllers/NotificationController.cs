using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [ApiController]
    [Route("api/Notifications")]
    public class NotificationController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public NotificationController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetNotifications()
        {
            var notifications = await _context.Notifications.ToListAsync();
            return Ok(notifications);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetNotification([FromRoute] int id)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification != null)
            {
                return Ok(notification);
            }

            return NotFound("Nie znaleziono zgłoszenia");
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteNotification([FromRoute] int id)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                _context.SaveChanges();
                return Ok("Zgłoszenie zostało usunięte");
            }

            return NotFound("Nie znaleziono zgłoszenia");
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateNotification([FromRoute] int id, Notification notificationUpdated)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification != null)
            {
                notification.Description = notificationUpdated.Description;
                _context.SaveChanges();
                return Ok("Zgłoszenie zostało edytowane");
            }

            return NotFound("Nie znaleziono zgłoszenia");
        }

        [HttpPost]

        public async Task<ActionResult> AddNotification(Notification notificationNew)
        {

            if (notificationNew != null)
            {
                _context.Notifications.Add(notificationNew);
                _context.SaveChanges();
                return Ok("Zgłoszenie zostało dodane");
            }

            return NotFound("Nie dodano zgłoszenia");
        }
    }
}
