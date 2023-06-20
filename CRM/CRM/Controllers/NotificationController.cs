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
        [Route("{id:int}")]
        public async Task<ActionResult> GetNotification([FromRoute] int id)
        {
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id== id);

            if (notification != null)
            {
                return Ok(notification);
            }

            return NotFound("Medical product not found");
        }
    }
}
