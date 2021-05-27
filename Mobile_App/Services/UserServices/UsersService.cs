using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Services.UserServices
{
    public class UsersService : IUsersService
    {
        private readonly MobileShopDbContext _context;

        public UsersService(MobileShopDbContext context)
        {
            _context = context;
        }

        // Add User service
        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);            
        }

        //Delete User service
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        //find user by id service
        public User FindUserById(int id)
        {
            return _context.Users.Find(id);
        }

        //get all user service
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        //get user by id service
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //update user service
        public void PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        //save change asynchornous
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()>=0);
        }

        //check user exist
        public bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Usersid == id);
        }
    }
}
