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
<<<<<<< HEAD
=======
            /////
>>>>>>> f6b2fd581639cdc490876dd6da106ecc4fcfab8a
            if (CheckPasword(password) >= 2) { 
                var user=await _UserRepository.GetUserToLogin(email, password);
                if(user != null) { 
                _logger.LogCritical($"login attempted with User Name , {email} and password{password}" );
                    return user;
              }
                return null;
            }
            return null;
            //throw new ConflictException();


        }
        public async Task<User> UpDateUser(int id, User userToUpdate)
        {
            if (CheckPasword(userToUpdate.Password) >= 2)
                return await _UserRepository.UpDateUser(id, userToUpdate);
            return null;
            
        }
        public int CheckPasword(string password)
        {
              var result = Zxcvbn.Core.EvaluatePassword(password);            
                return result.Score;
            
        }
        public async Task<User> checkIfUserExist(User userToRegister)
        {
            return await _UserRepository.checkIfUserExist(userToRegister);
        }
        public async Task<User> checkIfUserCanChange(int id,User userToUpDate)
        {
            var UserExist = await _UserRepository.checkIfUserExist(userToUpDate);
            if(UserExist!=null)
                {
                if (UserExist.UserId == id)
                    return userToUpDate;
            }
            return null;
        }
    }
}
