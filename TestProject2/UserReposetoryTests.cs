using Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Entities;  
using Repositories;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

public class UserRepositoryTests
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
    //[Fact]
    //public async Task Get_UserExists_ReturnsUser()
    //{
    //    // Arrange
    //    var mockContext = new Mock<_326774742WebApiContext>(); // Mock של הקונטקסט
    //    var userToReturn = new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" };

    //    // המוק של ה-DbSet מחזיר את המשתמש הרצוי כשה-id הוא 1
    //    mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync(userToReturn);

    //    var Reposetory = new UserRepository(mockContext.Object);

    //    // Act
    //    var result = await Reposetory.CreateUser(1); // קוראים לפונקציה עם id 1

    //    // Assert
    //    Assert.NotNull(result);  // תוודא שהמשתמש לא null
    //    Assert.Equal(1, result.Id); // תוודא שה-id הוא 1
    //    Assert.Equal("John", result.FirstName); // תוודא שהשם הפרטי הוא "John"
    //    Assert.Equal("Doe", result.LastName); // תוודא שהשם משפחה הוא "Doe"
    //    Assert.Equal("john.doe@example.com", result.Email); // תוודא שהדוא"ל נכון
    //}

    [Fact]
    public async Task Get_UserDoesNotExist_ReturnsNull()
    {
        // Arrange
        var mockContext = new Mock<_326774742WebApiContext>();

        // המוק של ה-DbSet מחזיר null כאשר לא נמצא משתמש עם ה-id המבוקש
        mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync((User)null);

        var Reposetory = new UserRepository(mockContext.Object);

        // Act
        var result = await Reposetory.Get(999); // קוראים לפונקציה עם id שלא קיים

        // Assert
        Assert.Null(result); // תוודא שהתוצאה היא null במקרה של id שלא קיים
    }


    //[Fact]
    //public async Task Post_User_ReturnsUser()
    //{
    //    // Arrange
    //    var mockContext = new Mock<MyShop214935017Context>(); // Mock של הקונטקסט
    //    var userToAdd = new User
    //    {
    //        Id = 1,
    //        FirstName = "John",
    //        LastName = "Doe",
    //        Email = "john.doe@example.com",
    //        Password = "securepassword"
    //    };

    //    // Setup של AddAsync כך שיחזיר את המשתמש שנוסף
    //    //mockContext.Setup(m => m.Users.AddAsync(It.IsAny<User>(), default)).ReturnsAsync(userToAdd);

    //    // Setup של SaveChangesAsync כך שיחזיר 1 (כלומר, השינויים נשמרו)
    //    mockContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);

    //    var Reposetory = new UserRepository(mockContext.Object);

    //    // Act
    //    var result = await Reposetory.Post(userToAdd); // קוראים לפונקציה עם המשתמש החדש

    //    // Assert
    //    Assert.NotNull(result);  // תוודא שהמשתמש לא null
    //    Assert.Equal(1, result.Id); // תוודא שה-id נכון
    //    Assert.Equal("John", result.FirstName); // תוודא שהשם הפרטי נכון
    //    Assert.Equal("Doe", result.LastName); // תוודא שהשם משפחה נכון
    //    Assert.Equal("john.doe@example.com", result.Email); // תוודא שהדוא"ל נכון

    //    // Verify שהתנהגויות מסוימות קרו
    //    mockContext.Verify(m => m.Users.AddAsync(It.IsAny<User>(), default), Times.Once); // תוודא ש-AddAsync נקרא פעם אחת
    //    mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once); // תוודא ש-SaveChangesAsync נקרא פעם אחת
    //}

    [Fact]
    public async Task Post_FailedToAddUser_ThrowsException()
    {
        // Arrange
        var mockContext = new Mock<_326774742WebApiContext>();
        var userToAdd = new User
        {
            UserId = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "securepassword"
        };

        // Setup של AddAsync כך שיזרוק Exception
        mockContext.Setup(m => m.Users.AddAsync(It.IsAny<User>(), default)).ThrowsAsync(new System.Exception("Failed to add user"));

        var Reposetory = new UserRepository(mockContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(async () => await Reposetory.Post(userToAdd)); // תוודא שהשגיאה נזרקת
    }

    //[Fact]
    //public async Task Put_UserExists_UpdatesUser()
    //{
    //    // Arrange
    //    var mockContext = new Mock<MyShop214935017Context>(); // Mock של הקונטקסט
    //    var userToUpdate = new User
    //    {
    //        Id = 1,
    //        FirstName = "John",
    //        LastName = "Doe",
    //        Email = "john.doe@example.com",
    //        Password = "securepassword"
    //    };

    //    var updatedUser = new User
    //    {
    //        Id = 1,
    //        FirstName = "Jane",
    //        LastName = "Doe",
    //        Email = "jane.doe@example.com",
    //        Password = "newpassword"
    //    };

    //    // Setup של Update כך שהיא לא תשפיע, רק תחזיר את המשתמש החדש
    //    //mockContext.Setup(m => m.Users.Update(It.IsAny<User>())).Returns(userToUpdate);
    //    //var mockSet = new Mock<DbSet<User>>();
    //    //mockContext.Setup(m => m.Users.Update(It.IsAny<User>())).Returns(mockSet.Object);


    //    // Setup של SaveChangesAsync כך שיחזיר 1 (העדכון התבצע)
    //    mockContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);

    //    var Reposetory = new UserRepository(mockContext.Object);

    //    // Act
    //    var result = await Reposetory.Put(1, updatedUser); // קוראים לפונקציה עם id 1 ועדכון למשתמש החדש

    //    // Assert
    //    Assert.NotNull(result); // תוודא שהתוצאה לא null
    //    Assert.Equal(1, result.Id); // תוודא שה-id נשאר כמו שהוא
    //    Assert.Equal("Jane", result.FirstName); // תוודא שהשם הפרטי מעודכן ל-"Jane"
    //    Assert.Equal("jane.doe@example.com", result.Email); // תוודא שהדוא"ל מעודכן
    //    mockContext.Verify(m => m.Users.Update(It.IsAny<User>()), Times.Once); // תוודא ש-Update נקרא פעם אחת
    //    mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once); // תוודא ש-SaveChangesAsync נקרא פעם אחת
    //}

    [Fact]
    public async Task Put_UserDoesNotExist_ThrowsException()
    {
        // Arrange
        var mockContext = new Mock<_326774742WebApiContext>();
        var userToUpdate = new User
        {
            UserId = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Password = "securepassword"
        };

        // Setup של Update כך שהיא לא תשפיע, רק תחזיר את המשתמש החדש
        mockContext.Setup(m => m.Users.Update(It.IsAny<User>()));

        // Setup של SaveChangesAsync כך שיזרוק Exception
        mockContext.Setup(m => m.SaveChangesAsync(default)).ThrowsAsync(new System.Exception("Failed to save changes"));

        var Reposetory = new UserRepository(mockContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<System.Exception>(async () => await Reposetory.UpDateUser(1, userToUpdate)); // תוודא שהשגיאה נזרקת
    }
    

}


