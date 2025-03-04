
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
//using Org.BouncyCastle.Asn1.Cmp;
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
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _UserService.GetUserById(id);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Postlogin([FromQuery] userLoginIdDTO userLoginIdDTO)
        {
            User SuccesGetUserToLogin =await _UserService.GetUserToLogin(userLoginIdDTO.Email, userLoginIdDTO.Password);
            if (SuccesGetUserToLogin != null)
            {
                return Ok(SuccesGetUserToLogin);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] userRegisterDTO userRegisterDTO)
        {
            User user = _mapper.Map<userRegisterDTO, User>(userRegisterDTO);
            User UserExist = await _UserService.checkIfUserExist(user);
            if (UserExist == null)
            {
                return Conflict("User already exist");
            }
            User newUser = await _UserService.CreateUser(user);
            Console.WriteLine(newUser);
            userIdDTO userDTO = _mapper.Map<User, userIdDTO>(newUser);
            if (newUser == null)
                return BadRequest("week password");
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] userRegisterDTO userToUpdate)
        {
            User user = _mapper.Map<userRegisterDTO, User>(userToUpdate);
            user.UserId= id;
            User UserCanChange = await _UserService.checkIfUserCanChange(id, user);
            if(UserCanChange != null)
            {
                await _UserService.UpDateUser(id, user);
                userIdDTO userDTO = _mapper.Map<User, userIdDTO>(user);
                if (userDTO == null)
                    return BadRequest();
                return Ok(userToUpdate);
            }
            return Conflict("User already exist");
                
            
        }
        [HttpPost]
        [Route("password")]
        public ActionResult<int> PostPassord([FromBody] string password)
        {
            int result = _UserService.CheckPasword(password);
            return result;
        }
    }
}
