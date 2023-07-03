using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;

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
        [Route("getUsersByRole/{role}")]
        public async Task<ActionResult> GetUsersByRole(string role)
        {
            var user = await _context.Users.Where(d => d.Role == role).ToListAsync();
            return Ok(user);
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult> GetUser([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("Nie znaleziono użytkownika");
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("userNotifications/{id:int}")]
        public async Task<ActionResult> GetUserNotifications([FromRoute] int id)
        {
            var notificationPerUser = _context.Users.Where(d => d.Id == id).SelectMany(d => d.Notifications);
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
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

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
                _context.Users.Add(userNew);
                _context.SaveChanges();
                return Ok("Użytkownik został dodany");
            }

            return NotFound("Nie dodano użytkownika");
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Ok("Użytkownik został usunięty");
            }

            return NotFound("Nie znaleziono użytkownika");
        }

        [HttpPost]
        [Route("GetLogInUser")]
        public async Task<ActionResult> GetLogInUser(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(d => d.Login == request.Login && d.Password == request.Password);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("Błędny login lub hasło");
        }
    }
}
