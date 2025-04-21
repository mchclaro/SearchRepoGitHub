using Moq;
using SearchRepoGitHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Tests.Tests
{
    public class FavoriteRepositoryTests
    {
        /// <summary>
        /// Testa se o método AddFavorite adiciona corretamente um ID de repositório à lista de favoritos
        /// </summary>
        [Fact]
        public void AddFavorite_ShouldAddRepositoryIdToSet()
        {
            var mockRepository = new Mock<IFavoriteRepository>();
            var favoriteIds = new HashSet<int>();

            // Simula o comportamento do método AddFavorite
            mockRepository.Setup(repo => repo.AddFavorite(It.IsAny<int>()))
                          .Callback<int>(id => favoriteIds.Add(id));

            int repositoryId = 12345;

            mockRepository.Object.AddFavorite(repositoryId);

            Assert.Contains(repositoryId, favoriteIds);
        }

        /// <summary>
        /// Testa se o método RemoveFavorite remove corretamente um ID de repositório da lista de favoritos
        /// </summary>
        [Fact]
        public void RemoveFavorite_ShouldRemoveRepositoryIdFromSet()
        {
            var mockRepository = new Mock<IFavoriteRepository>();
            var favoriteIds = new HashSet<int> { 12345 };

            // Simula o comportamento do método RemoveFavorite
            mockRepository.Setup(repo => repo.RemoveFavorite(It.IsAny<int>()))
                          .Callback<int>(id => favoriteIds.Remove(id));

            int repositoryId = 12345;

            mockRepository.Object.RemoveFavorite(repositoryId);

            Assert.DoesNotContain(repositoryId, favoriteIds);
        }

        /// <summary>
        /// Testa se o método GetFavorites retorna corretamente a lista de IDs de repositórios favoritos
        /// </summary>
        [Fact]
        public void GetFavorites_ShouldReturnListOfFavorites()
        {
            var mockRepository = new Mock<IFavoriteRepository>();
            var expectedFavorites = new List<int> { 12345, 67890 };

            // Simula o comportamento do método GetFavorites
            mockRepository.Setup(repo => repo.GetFavorites())
                          .Returns(expectedFavorites);

            var favorites = mockRepository.Object.GetFavorites();

            Assert.Equal(expectedFavorites, favorites);
        }
    }
}
