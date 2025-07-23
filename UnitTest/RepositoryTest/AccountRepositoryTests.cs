using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTest.RepositoryTest
{
    public class AccountRepositoryTests
    {
        private readonly Mock<AppDbContext> _mockContext;

        public AccountRepositoryTests()
        {
            _mockContext = new Mock<AppDbContext>();
        }

    }
}
