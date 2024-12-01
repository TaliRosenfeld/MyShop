using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> GetUserToLogin(string email, string password);
        Task UpDateUser(int id, User userToUpdate);
    }
}