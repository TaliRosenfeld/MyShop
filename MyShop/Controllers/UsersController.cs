
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Services;
using Entities;
using System;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "you", "succed!!!" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost()]
        [Route("login")]
        //public ActionResult<UserLogin> Postlogin([FromBody]UserLogin userlogin)
        //{
        //    User SuccesGetUserToLogin = _UserService.GetUserToLogin();
        //    if (SuccesGetUserToLogin != null)
        //    {
        //        return SuccesGetUserToLogin;
        //    }

        //    else
        //    {
        //        return NoContent();
        //    }
        //}
        public async Task<ActionResult<User>> Postlogin([FromQuery] string email, string password)
        {
            User SuccesGetUserToLogin =await _UserService.GetUserToLogin(email, password);
            if (SuccesGetUserToLogin != null)
            {
                return Ok(SuccesGetUserToLogin);
            }

            else
            {
                return NoContent();
            }
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            int passward = _UserService.CheckPasword(user.Password);
            if (passward >= 2)
            {
                User newUser = await _UserService.CreateUser(user);
                if (newUser == null)
                    return NoContent();
                return Ok(newUser);
            }
            else
            {
                return BadRequest();
            }


        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            int passward = _UserService.CheckPasword(userToUpdate.Password);
            if (passward >= 2)
            {
                await _UserService.UpDateUser(id, userToUpdate);
                Ok(userToUpdate);
            }
            else
            {
                BadRequest();
            }


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost()]
        [Route("password")]

        public ActionResult<int> PostPassord([FromBody] string password)
        {
            int result = _UserService.CheckPasword(password);
            return result;

        }
    }
}
