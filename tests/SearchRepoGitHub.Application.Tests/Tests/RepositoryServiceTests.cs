using Moq;
using SearchRepoGitHub.Application.Services;
using SearchRepoGitHub.Domain.Entities;
using SearchRepoGitHub.Domain.Interfaces;
using SearchRepoGitHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Application.Tests.Tests
{
    public class RepositoryServiceTests
    {
        /// <summary>
        /// Testa o método SearchRepositoriesAsync para garantir que ele retorna repositórios ordenados por relevância
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task SearchRepositoriesAsync_ShouldReturnOrderedByRelevance()
        {
            // Arrange
            var mockGitHubClient = new Mock<IGitHubClient>();
            var mockFavoriteRepository = new Mock<IFavoriteRepository>();

            mockGitHubClient.Setup(x => x.SearchRepositoriesAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Repository>
                {
                new() { Id = 1, Stars = 100, Forks = 50, Watchers = 20 },
                new() { Id = 2, Stars = 200, Forks = 10, Watchers = 5 }
                });

            var service = new RepositoryService(mockGitHubClient.Object, mockFavoriteRepository.Object);

            // Act
            var result = await service.SearchRepositoriesAsync("test");

            // Assert
            Assert.Equal(2, result.First().Id); // Repositório mais relevante primeiro
        }
    }
}
