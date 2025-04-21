using SearchRepoGitHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Domain.Tests.Tests
{
    public class RepositoryTests
    {
        /// <summary>
        /// Testa o método CalculateRelevance para garantir que ele retorna o valor correto
        /// </summary>
        [Fact]
        public void CalculateRelevance_ShouldReturnCorrectValue()
        {
            // Arrange
            var repository = new Repository
            {
                Stars = 100,
                Forks = 50,
                Watchers = 20
            };

            // Act
            double relevance = repository.CalculateRelevance();

            // Assert
            Assert.Equal(69.0, relevance); // Baseado na fórmula: (Stars * 0.5) + (Forks * 0.3) + (Watchers * 0.2)
        }
    }
}
