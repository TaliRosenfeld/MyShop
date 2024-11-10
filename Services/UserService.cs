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
        
        public User CreateUser(User user)
        {
            return _UserRepository.CreateUser(user);
        }
        public User GetUserToLogin(string email, string password)
        {
            return _UserRepository.GetUserToLogin(email, password);
        }
        public void UpDateUser(int id, User userToUpdate)
        {
            _UserRepository.UpDateUser(id, userToUpdate);
        }
        public int CheckPasword(string password)
        {
              var result = Zxcvbn.Core.EvaluatePassword(password);
              return result.Score;
        }
    }
}
