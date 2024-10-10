using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Moq;
using Service.Services;
using Xunit;

namespace UnitTest.ServiceTest
{
    public class AccountServiceTests
    {
        private readonly Mock<IAccountRepository> _mockRepository;
        private readonly AccountService _service;

        public AccountServiceTests()
        {
            _mockRepository = new Mock<IAccountRepository>();
            _service = new AccountService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAccountByUsernameAsync_ReturnsAccount()
        {
            // Arrange
            var username = "testuser";
            var account = new ACCOUNT { USERNAME = username };
            _mockRepository.Setup(r => r.GetAccountByUsernameAsync(username)).ReturnsAsync(account);

            // Act
            var result = await _service.GetAccountByUsernameAsync(username);

            // Assert
            Assert.Equal(account, result);
        }

        [Fact]
        public async Task GetAllAccountsAsync_ReturnsAllAccounts()
        {
            // Arrange
            var accounts = new List<ACCOUNT>
            {
                new ACCOUNT { USERNAME = "user1" },
                new ACCOUNT { USERNAME = "user2" }
            };
            _mockRepository.Setup(r => r.GetAllAccountsAsync()).ReturnsAsync(accounts);

            // Act
            var result = await _service.GetAllAccountsAsync();

            // Assert
            Assert.Equal(accounts, result);
        }

        [Fact]
        public async Task AddAccountAsync_AddsAccount()
        {
            // Arrange
            var account = new ACCOUNT { USERNAME = "newuser" };

            // Act
            await _service.AddAccountAsync(account);

            // Assert
            _mockRepository.Verify(r => r.AddAccountAsync(account), Times.Once);
        }

        [Fact]
        public async Task UpdateAccountAsync_UpdatesAccount()
        {
            // Arrange
            var account = new ACCOUNT { USERNAME = "existinguser" };

            // Act
            await _service.UpdateAccountAsync(account);

            // Assert
            _mockRepository.Verify(r => r.UpdateAccountAsync(account), Times.Once);
        }

        [Fact]
        public async Task DeleteAccountAsync_DeletesAccount()
        {
            // Arrange
            var username = "testuser";

            // Act
            await _service.DeleteAccountAsync(username);

            // Assert
            _mockRepository.Verify(r => r.DeleteAccountAsync(username), Times.Once);
        }
    }
}
