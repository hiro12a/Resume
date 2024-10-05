using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resume.DTO.Account;
using Resume.Models;
using Resume.Repository.IRepository;

namespace Resume.Controllers
{
    [Route("api/account")]
    public class AccountController : Controller
    {
        // Dependency injections
        private readonly UserManager<AppUsers> _usersManager;
        private readonly ITokenService _token;
        private readonly SignInManager<AppUsers> _signInManager;

        public AccountController(UserManager<AppUsers> userManager, ITokenService token, SignInManager<AppUsers> signInManager)
        {
            _usersManager = userManager;
            _signInManager = signInManager;
            _token = token;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            try
            {
                // Make sure the modelstate is valid first
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Get the data that the user input into registerDTO to appuser model
                var appUser = new AppUsers
                {
                    UserName = register.UserName,
                    Email = register.Email
                };

                // Create the user
                var createdUser = await _usersManager.CreateAsync(appUser, register.Password);
                if(createdUser.Succeeded) // Check to see if the user was successfully created
                {
                    // assign the role
                    var roleAssigned = await _usersManager.AddToRoleAsync(appUser, "User");
                    if(roleAssigned.Succeeded)
                    {
                        return Ok(
                            // Create a new instance of the NewUserDTO class with user information and a token
                            new NewUserDTO{
                                UserName = appUser.UserName,
                                Email = appUser.Email, 
                                Tokens = _token.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleAssigned.Errors);
                    }
                }
                else{
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            // Make sure the required fields are filled
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check to make sure the user exist
            var user = await _usersManager.Users.FirstOrDefaultAsync(x=>x.UserName == login.UserName.ToLower());
            if(user == null)
            {
                return Unauthorized("Invalid Username!");
            }

            // check the username and password
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if(!result.Succeeded)
            {
                return Unauthorized("Username or password is not correct!");
            }

            // Return the result
            return Ok(
                new NewUserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Tokens = _token.CreateToken(user)     
                }
            );

        }
    }
}