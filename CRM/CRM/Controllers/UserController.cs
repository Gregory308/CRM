using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public UserController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var user = await _context.User.ToListAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetUser([FromRoute] int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("Nie znaleziono użytkownika");
        }

        [HttpGet]
        [Route("userNotifications/{id:int}")]
        public async Task<ActionResult> GetUserNotifications([FromRoute] int id)
        {
            //var dupa = _context.User.Where(c => c.Id == id).Include(c => c.Notifications);
            var notificationPerUser = _context.Notifications.Where(d => d.UserId == id).ToList();
            if (notificationPerUser != null)
            {
                return Ok(notificationPerUser);
            }

            return NotFound("Nie znaleziono użytkownika");
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id, User userUpdated)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Name = userUpdated.Name;
                user.LastName = userUpdated.LastName;
                user.Email = userUpdated.Email;
                user.Role = userUpdated.Role;
                user.Login = userUpdated.Login;
                user.Password = userUpdated.Password;
                _context.SaveChanges();
                return Ok("Użytkownik został zmodyfikowany");
            }

            return NotFound("Użytkownik nie został zmodyfikowany");
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User userNew)
        {

            if (userNew != null)
            {
                _context.User.Add(userNew);
                _context.SaveChanges();
                return Ok("Użytkownik został dodany");
            }

            return NotFound("Nie dodano użytkownika");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
                return Ok("Użytkownik został usunięty");
            }

            return NotFound("Nie znaleziono użytkownika");
        }

    }
}
