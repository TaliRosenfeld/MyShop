using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Zxcvbn;




namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        
        //public int CheckPasword(string password)
        //{
        //    var result = Zxcvbn.Core.EvaluatePassword("p@ssw0rd");
        //    return result.Score;
        //}
        public User CreateUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("M:/Web-Api/MyShop/MyShop/FileUser.txt").Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("M:/Web-Api/MyShop/MyShop/FileUser.txt", userJson + Environment.NewLine);
            return user;
        }

        public User GetUserToLogin(string email, string password)
        {
            using (StreamReader reader = System.IO.File.OpenText("M:/Web-Api/MyShop/MyShop/FileUser.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User thisUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (thisUser.Email == email && thisUser.Password == password)

                        return thisUser;
                }
            }
            return null;
        }
        public void UpDateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("M:/Web-Api/MyShop/MyShop/FileUser.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;

                        
                }
                
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("M:/Web-Api/MyShop/MyShop/FileUser.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText("M:/Web-Api/MyShop/MyShop/FileUser.txt", text);
            }
        }


    }
}
