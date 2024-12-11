using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;


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
            User checkEmailuser = await contextDb.Users.FirstOrDefaultAsync(user => user.Email == newUser.Email);
            if (checkEmailuser == default)
            {
                //var res=await contextDb.Users.AddAsync(newUser);
                await contextDb.Users.AddAsync(newUser);
                await contextDb.SaveChangesAsync();
                //return res- the created user with the id
                return newUser;
            }
            else
                return null;            
        }

        public async Task<User> GetUserToLogin(string email, string password)
        {
                User user = await contextDb.Users.FirstOrDefaultAsync(user => user.Email == email && user.Password == password);
                return user;
        }
        public async Task UpDateUser(int id, User userToUpdate)//return user
        {
            userToUpdate.UserId = id;
            contextDb.Users.Update(userToUpdate);
            await contextDb.SaveChangesAsync();
        }


    }
}
