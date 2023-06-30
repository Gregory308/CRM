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
            var notifications = _context.Notifications.Include(d => d.Users);
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
        public async Task<ActionResult> UpdateNotification(NotificationEdit notificationUpdated)
        {
            var notification = _context.Notifications
                .Include(d => d.Users)
                .FirstOrDefault(x => x.Id == notificationUpdated.Id);

            if (notification != null)
            {
                if (notificationUpdated.Title.Length > 0)
                {
                    notification.Title = notificationUpdated.Title;
                }
                if (notificationUpdated.Description.Length > 0)
                {
                    notification.Description = notificationUpdated.Description;
                }
                if (notificationUpdated.UserIdToRemove != 0)
                {
                    var userToRemove = await _context.Users.FirstOrDefaultAsync(u => u.Id == notificationUpdated.UserIdToRemove);
                    if (userToRemove != null)
                    {
                        notification.Users.Remove(userToRemove);
                    }
                }
                if (notificationUpdated.UserIdToAdd != 0) 
                {
                    var userToAdd = await _context.Users.FirstOrDefaultAsync(x => x.Id == notificationUpdated.UserIdToAdd);
                    if (userToAdd != null)
                    {
                        notification.Users.Add(userToAdd);
                    }
                }

                _context.SaveChanges();
                return Ok("Zgłoszenie zostało edytowane");
            }

            return NotFound("Nie znaleziono zgłoszenia");
        }

        [HttpPut]
        [Route("AddCustToNotification/{idUser:int}/{idNot:int}")]
        public async Task<ActionResult> AddCustToNotification([FromRoute] int idUser, int idNot)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == idNot);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser);

            if (notification != null && user != null)
            {
                user.Notifications.Add(notification);
                _context.SaveChanges();
                return Ok("Zgłoszenie zostało edytowane");
            }

            return NotFound("Nie znaleziono zgłoszenia");
        }

        [HttpPost]
        public async Task<ActionResult> AddNotification(Notification notificationNew, int id)
        {

            if (notificationNew != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                {
                    user.Notifications.Add(notificationNew);
                    //_context.Notifications.Add(notificationNew);
                    _context.SaveChanges();
                    return Ok("Zgłoszenie zostało dodane");
                }
            }

            return NotFound("Nie dodano zgłoszenia");
        }
    }
}
