using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service.Interfaces;
using WebAPI.Controllers;

namespace UnitTest.ControllerTest
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _mockService;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockService = new Mock<IAccountService>();
            _controller = new AccountController(_mockService.Object);
        }

        [Fact]
        public async Task GetAccount_ReturnsAccount()
        {
            // Arrange
            var username = "testuser";
            var account = new ACCOUNT { USERNAME = username };
            _mockService.Setup(s => s.GetAccountByUsernameAsync(username)).ReturnsAsync(account);

            // Act
            var result = await _controller.GetAccount(username);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(account, okResult.Value);
        }

        [Fact]
        public async Task GetAccount_ReturnsNotFound()
        {
            // Arrange
            var username = "nonexistentuser";
            _mockService.Setup(s => s.GetAccountByUsernameAsync(username)).ReturnsAsync((ACCOUNT)null);

            // Act
            var result = await _controller.GetAccount(username);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllAccounts_ReturnsAllAccounts()
        {
            // Arrange
            var accounts = new List<ACCOUNT>
            {
                new ACCOUNT { USERNAME = "user1" },
                new ACCOUNT { USERNAME = "user2" }
            };
            _mockService.Setup(s => s.GetAllAccountsAsync()).ReturnsAsync(accounts);

            // Act
            var result = await _controller.GetAllAccounts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(accounts, okResult.Value);
        }

        [Fact]
        public async Task AddAccount_AddsAccount()
        {
            // Arrange
            var account = new ACCOUNT { USERNAME = "newuser" };

            // Act
            var result = await _controller.AddAccount(account);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(account, createdAtActionResult.Value);
            Assert.Equal("GetAccount", createdAtActionResult.ActionName);
            Assert.Equal(account.USERNAME, createdAtActionResult.RouteValues["username"]);
        }

        [Fact]
        public async Task UpdateAccount_UpdatesAccount()
        {
            // Arrange
            var username = "existinguser";
            var account = new ACCOUNT { USERNAME = username };

            // Act
            var result = await _controller.UpdateAccount(username, account);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateAccount_ReturnsBadRequest()
        {
            // Arrange
            var username = "existinguser";
            var account = new ACCOUNT { USERNAME = "differentuser" };

            // Act
            var result = await _controller.UpdateAccount(username, account);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteAccount_DeletesAccount()
        {
            // Arrange
            var username = "testuser";

            // Act
            var result = await _controller.DeleteAccount(username);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
