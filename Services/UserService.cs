using Entities;
using Repositories;
using Zxcvbn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepository UserRepository, ILogger<UserService> logger)
        {
            _UserRepository = UserRepository;
            _logger = logger;
        }
        public async Task<User> GetUserById(int id)
        {
           return await _UserRepository.GetUserById(id);
        }
        public async Task<User> CreateUser(User user)
        {
            if (CheckPasword(user.Password) >= 2)
                return await _UserRepository.CreateUser(user);
            return null;
        }
        public async  Task<User> GetUserToLogin(string email, string password)
        {
            
            if (CheckPasword(password) >= 2) { 
                
                var user=await _UserRepository.GetUserToLogin(email, password);
                if(user != null) { 
                _logger.LogCritical($"login attempted with User Name , {email} and password{password}" );
                    return user;
              }
            }
           return null;
            
        }
        public async Task<User> UpDateUser(int id, User userToUpdate)
        {
            return await _UserRepository.UpDateUser(id, userToUpdate);
        }
        public int CheckPasword(string password)
        {
              var result = Zxcvbn.Core.EvaluatePassword(password);            
                return result.Score;
            
        }
    }
}
