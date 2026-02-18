using FluentAssertions;
using Moq;
using UserRecord.Api.DTOs;
using UserRecord.Api.Models;
using UserRecord.Api.Repositories;
using UserRecord.Api.Services;

namespace UserRecord.Tests;

public class UserTests
{
    private readonly Mock<IUserRepository> _repoMock;
    private readonly UserService _service;

    public UserTests()
    {
        _repoMock = new Mock<IUserRepository>();
        _service = new UserService(_repoMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenUserNotFound()
    {
        _repoMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((User?)null);

        var result = await _service.GetByIdAsync(Guid.NewGuid());

        result.Should().BeNull();
    }

    [Fact]
    public async Task CreateAsync_CreatesUser()
    {
        var dto = new CreateUserDto
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@test.com"
        };

        var result = await _service.CreateAsync(dto);

        result.FirstName.Should().Be("John");

        _repoMock.Verify(r => r.CreateAsync(It.IsAny<User>()), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
