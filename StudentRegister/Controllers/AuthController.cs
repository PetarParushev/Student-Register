using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentRegister.Data.Context;
using StudentRegister.Data.Entities;
using StudentRegister.Models;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly StudentRegisterDBContext context;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration config;

        public AuthController(StudentRegisterDBContext context, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration config)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.config = config;
        }

        [HttpGet("email/{input}")]
        public async Task<IActionResult> CheckEmail(string input)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == input.ToLower());
            if (user != null)
            {
                return Ok(user.Email);
            }
            return Ok(null);
        }

        [HttpGet("username/{input}")]
        public async Task<IActionResult> CheckUsername(string input)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == input.ToLower());
            if (user != null)
            {
                return Ok(user.UserName);
            }
            return Ok(null);
        }

        // POST: api/Auth/Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateAccountViewModel model)
        {
            var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email || u.UserName == model.Username);
            if (existingUser != null)
            {
                return Ok("User already exists.");
            }

            User user = new User
            {
                Email = model.Email,
                UserName = model.Username
            };

            var newUser = await userManager.CreateAsync(user);
            if (!newUser.Succeeded)
            {
                return Ok("Error: Could not create user.");
            }

            newUser = await userManager.AddPasswordAsync(user, model.Password);
            await signInManager.SignInAsync(user, isPersistent: false);
            return Ok("User successfully created!");
        }

        // POST: api/Auth/Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CreateAccountViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Ok("Error: Wrong credentials");
            }

            var loggedUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,loggedUser.Id.ToString()),
                new Claim(ClaimTypes.Name,loggedUser.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(config.GetSection("JwtSettings:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var returnToken = tokenHandler.WriteToken(token);

            loggedUser.Token = returnToken;

            return Ok(loggedUser);
        }

        // GET: api/Auth/Logout
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Logged out!");
        }
    }
}