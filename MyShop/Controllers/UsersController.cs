
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Services;
using Entities;
using System;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using DTO;
using AutoMapper;
using System.Reflection.Metadata.Ecma335;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        IMapper _mapper;
        private readonly IUserService _UserService;
        public UsersController(IUserService UserService, IMapper Imapper)
        {
            _UserService = UserService;
            _mapper = Imapper;
        }

        [HttpPost()]
        [Route("login")]
        public async Task<ActionResult<User>> Postlogin([FromQuery] userLoginIdDTO userLoginIdDTO)
        {
            User SuccesGetUserToLogin =await _UserService.GetUserToLogin(userLoginIdDTO.Email, userLoginIdDTO.Password);
            if (SuccesGetUserToLogin != null)
            {
                return Ok(SuccesGetUserToLogin);
            }
            else
            {
                return BadRequest("week password"); ;
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<userIdDTO>> Post([FromBody] userRegisterDTO userRegisterDTO)
        {
                User user = _mapper.Map<userRegisterDTO, User>(userRegisterDTO);
                User newUser = await _UserService.CreateUser(user);
                userIdDTO userDTO = _mapper.Map<User,userIdDTO>(newUser);
                if (userDTO == null)
                    return BadRequest("week password");
                return Ok(userDTO);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] userRegisterDTO userToUpdate)
        {
                User user = _mapper.Map<userRegisterDTO, User>(userToUpdate);
                await _UserService.UpDateUser(id, user);
                userIdDTO userDTO = _mapper.Map<User, userIdDTO>(user);
                if (userDTO == null)
                    return BadRequest();
                return Ok(userToUpdate);
            
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
