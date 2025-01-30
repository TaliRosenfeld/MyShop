using Entities;
using Repositories;
using Moq;



namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var user = new User { Password = "Tt123456!", Email = "tali@gmail.com" };
            var mockContext = new Mock<_326774742WebApiContext>();
            var users = new List<User> { user };
            mockContext.Setup(X => X.User).ReturnDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.GetUserToLogin(user.Email, user.Password);
            Assert.Equal(user, result);

        }
    }
}