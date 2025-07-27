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
        private static string GenerateSalt(int size = 32)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var saltBytes = new byte[size];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string salt)
        {
            var sha256 = System.Security.Cryptography.SHA256.Create();
            var combined = Encoding.UTF8.GetBytes(password + salt);
            var hash = sha256.ComputeHash(combined);
            return Convert.ToBase64String(hash);
        }

        public async Task<User> CreateUser(User user)
        {
            if (CheckPasword(user.Password) >= 2)
            {
                string salt = GenerateSalt();
                string hash = HashPassword(user.Password, salt);
                user.Password = hash;
                user.Salt = salt;
                return await _UserRepository.CreateUser(user);
            }
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
