using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        _326774742WebApiContext contextDb;

        public UserRepository(_326774742WebApiContext _326774742WebApiContext)
        {
            contextDb = _326774742WebApiContext;
        }

        public async Task<User> CreateUser(User newUser)
        {
                var newUserWithId =await contextDb.Users.AddAsync(newUser);
                await contextDb.SaveChangesAsync();
                newUser.UserId = newUserWithId.Entity.UserId;   
                return newUser;
        }
        public async Task<User> GetUserById(int id)
        {
           return await contextDb.Users.FirstOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<User> GetUserToLogin(string email, string password)
        {
            /////
            User user = await contextDb.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
                return user;
            

        }
        public async Task<User> UpDateUser(int id, User userToUpdate)
        {
            User checkEmailuser = await checkIfUserExist(userToUpdate);
            if (checkEmailuser !=null)
            {
                userToUpdate.UserId = id;
                contextDb.Users.Update(userToUpdate);
                await contextDb.SaveChangesAsync();
                return userToUpdate;
            }
            else
                return null;            
        }
        public async Task<User> checkIfUserExist(User userToRegister)
        {
            User UserExist = await contextDb.Users.FirstOrDefaultAsync(user => user.Email == userToRegister.Email);
            if (UserExist == default)
               return userToRegister;
            return null;
        }
        //public async Task<User> checkIfUserCanChange(int id,User userToUpdate)
        //{
        //    User UserExist = await checkIfUserExist(userToUpdate);
        //}



    }
}
