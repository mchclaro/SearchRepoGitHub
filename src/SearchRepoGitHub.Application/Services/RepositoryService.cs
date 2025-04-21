using SearchRepoGitHub.Application.DTOs;
using SearchRepoGitHub.Domain.Entities;
using SearchRepoGitHub.Domain.Interfaces;
using SearchRepoGitHub.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepoGitHub.Application.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IGitHubClient _gitHubClient;
        private readonly IFavoriteRepository _favoriteRepository;

        public RepositoryService(IGitHubClient gitHubClient, IFavoriteRepository favoriteRepository)
        {
            _gitHubClient = gitHubClient;
            _favoriteRepository = favoriteRepository;
        }

        /// <summary>
        /// Busca repositórios com base em uma query de pesquisa
        /// </summary>
        /// <param name="query">O termo de busca para filtrar repositórios</param>
        /// <returns>Uma lista de repositórios que correspondem a query, ordenados por relevância</returns>
        public async Task<IEnumerable<IRepositoryDto>> SearchRepositoriesAsync(string query)
        {
            var repositories = await _gitHubClient.SearchRepositoriesAsync(query);

            // Mapeia os repositórios para DTOs e ordena por relevância
            return repositories
                .Select(repo => new RepositoryDto
                {
                    Id = repo.Id,
                    Name = repo.Name,
                    Stars = repo.Stars,
                    Forks = repo.Forks,
                    Watchers = repo.Watchers,
                    IsFavorite = _favoriteRepository.IsFavorite(repo.Id)
                })
                .OrderByDescending(repo => CalculateRelevance(repo.Stars, repo.Forks, repo.Watchers))
                .ToList();
        }

        /// <summary>
        /// Alterna o status de favorito de um repositório (marca ou desmarca como favorito)
        /// </summary>
        /// <param name="repositoryId">O ID do repositório que vai ser alterado</param>
        public void ToggleFavorite(int repositoryId)
        {
            if (_favoriteRepository.IsFavorite(repositoryId))
                _favoriteRepository.RemoveFavorite(repositoryId);
            else
                _favoriteRepository.AddFavorite(repositoryId);
        }

        /// <summary>
        /// Obtém os repositórios favoritos do usuário
        /// </summary>
        /// <returns>Uma lista de repositórios favoritos</returns>
        public async Task<IEnumerable<IRepositoryDto>> GetFavoriteRepositoriesAsync()
        {
            // Obtém os IDs dos repositórios favoritos
            var favoriteIds = _favoriteRepository.GetFavorites();

            // Busca apenas os repositórios favoritos
            var favoriteRepositories = await _gitHubClient.GetAllRepositoriesAsync(favoriteIds);

            // Mapeia os repositórios para DTOs
            return favoriteRepositories.Select(repo => new RepositoryDto
            {
                Id = repo.Id,
                Name = repo.Name,
                Stars = repo.Stars,
                Forks = repo.Forks,
                Watchers = repo.Watchers,
                IsFavorite = true
            }).ToList();
        }

        /// <summary>
        /// Calcula a relevância de um repositório com base em estrelas, forks e watchers.
        /// </summary>
        /// <param name="stars">O número de estrelas do repositório</param>
        /// <param name="forks">O número de forks do repositório</param>
        /// <param name="watchers">O número de watchers do repositório</param>
        /// <returns></returns>
        private double CalculateRelevance(int stars, int forks, int watchers) =>
            // Lógica de relevância: estrelas (50%), forks (30%), watchers (20%)
            (stars * 0.5) + (forks * 0.3) + (watchers * 0.2);
    }
}
