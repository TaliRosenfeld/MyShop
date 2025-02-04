using System.Reflection.Metadata;
using Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;



namespace TestProject
{
    public class UnitTest
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnUser()
        {
            
            var user = new User { Email = "cx@aaaaa", Password = "aaa@aaqaaq1222" };
            var mockContext = new Mock<_326774742WebApiContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepository(mockContext.Object);
            var result = await userRepository.GetUserToLogin(user.Email, user.Password);
            Assert.Equal(user, result);
        }
    }
}