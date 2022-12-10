using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdisonCV_EF_P6_22_3_API.Models;
using EdisonCV_EF_P6_22_3_API.Models.DTOs;



namespace EdisonCV_EF_P6_22_3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class UsersController : ControllerBase
    {
        private readonly AnswersDBContext _context;

        public UsersController(AnswersDBContext context)
        {
            _context = context;
        }


     






        // GET: api/Users/GetUserInfo?id=3
        [HttpGet("GetUserInfo")]
        public ActionResult<IEnumerable<UserDTO>> GetUserInfo(int id)
        {
            //las consultas linq se parece a los normales.
            var query = (from u in _context.Users
                         where u.UserId == id
                         select new
                         {
                             idusuario = u.UserId,
                             email = u.UserName,
                             nombre  = u.FirstName,
                         apellido = u.LastName,
                            telefono  = u.PhoneNumber,
                           password   = u.UserPassword,
                            strike  = u.StrikeCount,
                           emailRespaldo   = u.BackUpEmail,
                           descripcionJob   = u.JobDescription,
                            status  = u.UserStatusId,
                            idcountry  = u.CountryId,
                            idUserRole  = u.UserRoleId


                         }).ToList();
            List<UserDTO> list = new List<UserDTO>();

            foreach (var item in query)
            {
                UserDTO NewItem = new UserDTO();

                NewItem.UserId = item.idusuario;
                NewItem.UserName = item.email;
                NewItem.FirstName = item.nombre;
                NewItem.LastName = item.apellido;
                NewItem.PhoneNumber = item.telefono;
                NewItem.UserPassword = item.password;
                NewItem.StrikeCount = item.strike;
                NewItem.BackUpEmail = item.emailRespaldo;
                NewItem.JobDescription = item.descripcionJob;
                NewItem.UserStatusId = item.status;
                NewItem.CountryId = item.idcountry;
                NewItem.UserRoleId = item.idUserRole;
                list.Add(NewItem);
            }




            if (list == null)
            {
                return NotFound();
            }

            return list;
        }






        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
