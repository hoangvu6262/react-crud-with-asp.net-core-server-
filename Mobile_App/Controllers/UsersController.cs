using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_App.Models;
using Mobile_App.Services.UserServices;

namespace Mobile_App.Controllers
{
    [Route("api/UserManagement/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _repository;

        public UsersController(IUsersService repository)
        {
            _repository = repository;
        }

        // GET: api/UserManagement/Users
        [HttpGet("getalluser")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _repository.GetAllUser();
        }

        // GET: api/UserManagement/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var users = await _repository.GetUserById(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        //GET: api/UserManagement/Users/TimKiem/1123
        [HttpGet("TimKiem/{taiKhoan}")]
        public async Task<ActionResult<User>> FindUser(string taiKhoan)
        {
            var users = await _repository.FindUserByAccount(taiKhoan);
            Console.WriteLine(users);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/UserManagement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            user.Usersid = id;
            _repository.PutUser(id, user);

            try
            {
                await _repository.SaveChangeAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST:api/UserManagement/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _repository.AddUser(user);
            await _repository.SaveChangeAsync();

            return CreatedAtAction("GetUserById", new { id = user.Usersid }, user);
        }

        // DELETE: api/UserManagement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = _repository.FindUserById(id);
            if (users == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(users);
            await _repository.SaveChangeAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _repository.UsersExists(id);
        }
    }
}
