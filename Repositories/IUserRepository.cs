using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserToLogin(string email, string password);
        Task<User> UpDateUser(int id, User userToUpdate);
    }
}