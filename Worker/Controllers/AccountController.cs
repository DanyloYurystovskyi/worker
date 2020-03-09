using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Worker.BLL.DTOs.Account;
using Worker.BLL.Mapper;
using Worker.DAL.Entities;

namespace Worker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserMapper _userMapper;

        public AccountController(UserManager<User> userManager, IUserMapper userMapper)
        {
            _userManager = userManager;
            _userMapper = userMapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO model)
        {
            var user = _userMapper.GetUser(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (await _userManager.CheckPasswordAsync(user, model.Password))
            {
                //string token = await _userManager.GetAuthenticationTokenAsync(user);
            }
            //create jwt token
            return Ok();
        }
    }
}