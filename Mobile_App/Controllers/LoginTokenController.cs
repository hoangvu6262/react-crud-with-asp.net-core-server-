using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mobile_App.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly MobileShopDbContext _context;

        public LoginTokenController(IConfiguration config, MobileShopDbContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Users _userData)
        {

            if (_userData != null && _userData.taiKhoan != null && _userData.matKhau != null)
            {
                var user = await GetUser(_userData.taiKhoan, _userData.matKhau);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("id", user.id.ToString()),
                    new Claim("hoTen", user.hoTen),
                    new Claim("taiKhoan", user.taiKhoan),
                    new Claim("email", user.email),
                    new Claim("soDt", user.soDt),
                    new Claim("maLoaiNguoiDung", user.maLoaiNguoiDung)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var tokenString = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    var accessToken = Ok(new JwtSecurityTokenHandler().WriteToken(tokenString));

                    var response = Ok(new { 
                        id = user.id, 
                        taiKhoan = user.taiKhoan,
                        matKhau = user.matKhau,
                        hoTen = user.hoTen, 
                        soDt = user.soDt,
                        maLoaiNguoiDung = user.maLoaiNguoiDung,
                        token = accessToken.Value
                    });

                    return response;
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Users> GetUser(string taiKhoan, string matKhau)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.taiKhoan == taiKhoan && u.matKhau == matKhau);
        }
    }
}
