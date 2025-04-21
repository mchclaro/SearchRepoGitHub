using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SearchRepoGitHub.API.Controllers;
using SearchRepoGitHub.API.DTOs;
using SearchRepoGitHub.Application.DTOs;
using SearchRepoGitHub.Domain.Interfaces;
using Xunit;

namespace SearchRepoGitHub.API.Tests;

public class RepositoriesControllerTests
{
    /// <summary>
    /// Testa se o endpoint /api/repositories?query=dotnet retorna uma lista de repositórios correspondentes à query.
    /// </summary>
    [Fact]
    public async Task SearchRepositories_ShouldReturnOkWithMatchingRepositories()
    {
        // Arrange
        var mockRepositoryService = new Mock<IRepositoryService>();
        var expectedRepositories = new List<RepositoryDto>
        {
            new() {
                Id = 1,
                Name = "dotnet/runtime",
                Stars = 12000,
                Forks = 2000,
                Watchers = 1000,
                IsFavorite = false
            },
            new() {
                Id = 2,
                Name = "dotnet/aspnetcore",
                Stars = 9000,
                Forks = 1500,
                Watchers = 800,
                IsFavorite = true
            }
        };

        mockRepositoryService
            .Setup(service => service.SearchRepositoriesAsync("dotnet"))
            .ReturnsAsync(expectedRepositories);

        var controller = new RepositoriesController(mockRepositoryService.Object);

        var result = await controller.SearchRepositories(new SearchRepositoryQueryDto { Query = "dotnet" });

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedRepositories = Assert.IsAssignableFrom<IEnumerable<RepositoryDto>>(okResult.Value);

        Assert.Equal(expectedRepositories, returnedRepositories);
    }

    /// <summary>
    /// Testa se o endpoint /api/repositories/{repositoryId}/favorite alterna corretamente o status de favorito.
    /// </summary>
    [Fact]
    public void ToggleFavorite_ShouldCallToggleFavoriteOnService()
    {
        var mockRepositoryService = new Mock<IRepositoryService>();
        var controller = new RepositoriesController(mockRepositoryService.Object);
        int repositoryId = 12345;

        controller.ToggleFavorite(repositoryId);

        mockRepositoryService.Verify(service => service.ToggleFavorite(repositoryId), Times.Once);
    }
}