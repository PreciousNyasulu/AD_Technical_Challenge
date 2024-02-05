using Xunit;
using NaLib.Models;
using NaLib.Services;
using NaLib;
using Moq;

public class UserServiceTests
{
    [Fact]
    public void ConfirmUser_CorrectCredentials_ReturnsSuccess()
    {
        var userRepository = new Mock<IRepository<Users>>();
        var userService = new UserService(userRepository.Object);
        var loginPayload = new LoginPayload { Username = "testuser", Password = "password" };

        var result = userService.ConfirmUser(new Users { UserName = "testuser", Password = "password" });

        Assert.Equal(LoginStatus.Success, result);
    }

    [Fact]
    public void ConfirmUser_IncorrectPassword_ReturnsIncorrectPassword()
    {
        var userRepository = new Mock<IRepository<Users>>();
        var userService = new UserService(userRepository.Object);
        var loginPayload = new LoginPayload { Username = "testuser", Password = "incorrectpassword" };

        var result = userService.ConfirmUser(new Users { UserName = "testuser", Password = "correctpassword" });

        Assert.Equal(LoginStatus.IncorrectPassword, result);
    }
}
