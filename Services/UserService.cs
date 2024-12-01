using Entities;
using Repositories;
using Zxcvbn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        
        public async Task<User> CreateUser(User user)
        {
            return await _UserRepository.CreateUser(user);
        }
        public async  Task<User> GetUserToLogin(string email, string password)
        {
            return await _UserRepository.GetUserToLogin(email, password);
        }
        public async Task UpDateUser(int id, User userToUpdate)
        {
            await _UserRepository.UpDateUser(id, userToUpdate);
        }
        public int CheckPasword(string password)
        {
              var result = Zxcvbn.Core.EvaluatePassword(password);
              return result.Score;
        }
    }
}
