using Entities;

namespace Services
{
    public interface IUserService
    {
        int CheckPasword(string password);
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> GetUserToLogin(string email, string password);
        Task<User> UpDateUser(int id, User userToUpdate);
        Task<User> checkIfUserExist(User userToRegister);
        Task<User> checkIfUserCanChange(int id,User userToRegister);

    }
}
//