using Entities;

namespace Services
{
    public interface IUserService
    {
        int CheckPasword(string password);
        User CreateUser(User user);
        User GetUserToLogin(string email, string password);
        void UpDateUser(int id, User userToUpdate);
    }
}