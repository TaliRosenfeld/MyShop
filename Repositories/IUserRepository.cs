using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User GetUserToLogin(string email, string password);
        void UpDateUser(int id, User userToUpdate);
    }
}