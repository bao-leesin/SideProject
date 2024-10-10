using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTest.RepositoryTest
{
    public class AccountRepositoryTests
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly AccountRepository _repository;

        public AccountRepositoryTests()
        {
            _mockContext = new Mock<AppDbContext>();
            _repository = new AccountRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAccountByUsernameAsync_ReturnsAccount()
        {
            // Arrange
            var username = "testuser";
            var account = new ACCOUNT { USERNAME = username };
            _mockContext.Setup(c => c.ACCOUNTs.FindAsync(username)).ReturnsAsync(account);

            // Act
            var result = await _repository.GetAccountByUsernameAsync(username);

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

            // Act
            var result = await _repository.GetAllAccountsAsync();

            // Assert
            Assert.Equal(accounts, result);
        }

        [Fact]
        public async Task AddAccountAsync_AddsAccount()
        {
            // Arrange
            var account = new ACCOUNT { USERNAME = "newuser" };
            _mockContext.Setup(c => c.ACCOUNTs.AddAsync(account, default)).ReturnsAsync((Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ACCOUNT>)null);

            // Act
            await _repository.AddAccountAsync(account);

            // Assert
            _mockContext.Verify(c => c.ACCOUNTs.AddAsync(account, default), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task UpdateAccountAsync_UpdatesAccount()
        {
            // Arrange
            var account = new ACCOUNT { USERNAME = "existinguser" };

            // Act
            await _repository.UpdateAccountAsync(account);

            // Assert
            _mockContext.Verify(c => c.ACCOUNTs.Update(account), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task DeleteAccountAsync_DeletesAccount()
        {
            // Arrange
            var username = "testuser";
            var account = new ACCOUNT { USERNAME = username };
            _mockContext.Setup(c => c.ACCOUNTs.FindAsync(username)).ReturnsAsync(account);

            // Act
            await _repository.DeleteAccountAsync(username);

            // Assert
            _mockContext.Verify(c => c.ACCOUNTs.Remove(account), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
