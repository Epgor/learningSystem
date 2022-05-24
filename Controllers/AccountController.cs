using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using learningSystem.Models;
using learningSystem.Services;
using Microsoft.AspNetCore.Authorization;
using learningSystem.Entities;

namespace learningSystem.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);
            return Ok(token);
        }

        [HttpPut("role")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Role([FromBody]RoleDto dto)
        {
            _accountService.ChangeRole(dto);
            return Ok();
        }

        [HttpGet("user/{id}")]
        //[Authorize(Roles = "Admin,Mod")]
        public ActionResult<UserDto> GetById([FromRoute]int id)
        {
            var user = _accountService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("users")]
        public ActionResult<List<UserDto>> GetAll()
        {
            var users = _accountService.GetUsers();
            return Ok(users);
        }

        [HttpGet("learningtype/{userId}")]
        [AllowAnonymous]
        public ActionResult<int> GetUserLearningType([FromRoute] int userId)
        {
            var type = _accountService.GetLearinngType(userId);
            return Ok(type);
        }
    }
}
