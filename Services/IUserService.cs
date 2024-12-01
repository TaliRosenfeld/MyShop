using Entities;

namespace Services
{
    public interface IUserService
    {
        int CheckPasword(string password);
        Task<User> CreateUser(User user);
        Task<User> GetUserToLogin(string email, string password);
        Task UpDateUser(int id, User userToUpdate);
    }
}