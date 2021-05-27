using Microsoft.AspNetCore.Mvc;
using Mobile_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Services.UserServices
{
    public interface IUsersService
    {
        bool UsersExists(int id);

        Task<bool> SaveChangeAsync();

        Task<ActionResult<IEnumerable<User>>> GetAllUser();

        Task<ActionResult<User>> GetUserById(int id);

        Task<ActionResult<User>> FindUserByAccount(string account);

        void AddUser(User newUser);

        void PutUser(int id, User user);

        void DeleteUser(User user);

        User FindUserById(int id);


    }
}
