//using Entities;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Moq.EntityFrameworkCore;
//using Repositories;

//using TestProject;
//namespace TestMyShop
//{
//    public class IntegrationTest : IClassFixture<DatabaseFixture>
//    {
//        _326774742WebApiContext _context;
//        public IntegrationTest(DatabaseFixture fixture)
//        {
//            _context = fixture.Context;
//        }

//        [Fact]
//        public async Task Get_ShouldReturnUser_WhenUserExists()
//        {
//            // Arrange
//            var user = new User { FirstName="tali",LastName="rosenfeld", Email = "tes@example.com", Password = "PaSs#WoRd$$123#" };
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            // Act
//            var retrievedUser = await _context.Users.FindAsync(user.UserId);

//            // Assert
//            Assert.NotNull(retrievedUser);
//            Assert.Equal(user.Email, retrievedUser.Email);
//            Assert.Equal(user.Password, retrievedUser.Password);
//        }
//    }
//}
using Entities;
//using NuGet.Protocol.Core.Types;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TestNyShop.Reposetories;
using Xunit;
//using Tests;

namespace TestProject
{
    public class IntegrationTest : IClassFixture<DatabaseFixture>
    {
        private readonly _326774742WebApiContext _context;
        private readonly UserRepository _reposetory;

        public IntegrationTest(DatabaseFixture fixture)
        {
            _context = fixture.Context; // שימוש ב-DbContext מהפיקסצ'ר
            _reposetory = new UserRepository(_context);
        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var user = new User { Email = "test1@example.com", Password = "password123", FirstName = "pppp", LastName = "vgfcgfc" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var retrievedUser = await _context.Users.FindAsync(user.UserId);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);
        }
        [Fact]
        public async Task Get_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Act
            var retrievedUser = await _reposetory.GetUserById(-1); // מזהה לא קיים

            // Assert
            Assert.Null(retrievedUser);
        }
        [Fact]
        public async Task Post_ShouldAddUser_WhenUserIsValid()
        {
            // Arrange
            var user = new User { Email = "nnnewuser@example.com", Password = "Tt12345@@", FirstName="gjh" ,LastName="gjf"  };


            // Act
            var addedUser = await _reposetory.CreateUser(user);


            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal(user.Email, addedUser.Email);
            Assert.True(addedUser.UserId > 0); // נניח שהמזהה יוקצה אוטומטית
        }


        [Fact]
        public async Task Login_ShouldReturnUser_WhenCredentialsAreValid()
        {
            // Arrange
            var user = new User { Email = "ttestuser@example.com", Password = "Tt123456@@", FirstName = "gjh", LastName = "gjf" };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Act
            var loggedInUser = await _reposetory.GetUserToLogin(user.Email, user.Password);


            // Assert
            Assert.NotNull(loggedInUser);
            Assert.Equal(user.Email, loggedInUser.Email);
        }

        [Fact]
        public async Task Login_ShouldReturnNull_WhenCredentialsAreInvalid()
        {
            // Act
            var loggedInUser = await _reposetory.GetUserToLogin("unknown@example.com", "wrongpasswo");


            // Assert
            Assert.Null(loggedInUser);
        }

    }
}