using Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;

using TestProject;
namespace TestMyShop
{
    public class IntegrationTest : IClassFixture<DatabaseFixture>
    {
        _326774742WebApiContext _context;
        public IntegrationTest(DatabaseFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { FirstName="tali",LastName="rosenfeld", Email = "test@example.com", Password = "password123" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var retrievedUser = await _context.Users.FindAsync(user.UserId);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);
        }
    }
}
